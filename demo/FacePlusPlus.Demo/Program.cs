using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FacePlusPlus.Demo
{
    class Program
    {
        const string API_Key = "";
        const string API_Secret = "";
        static APIClient client = null;
        const string store_path = "./store.json";

        static void Main(string[] args)
        {
            // init face++ client 
            client = new APIClient(API_Key, API_Secret);

            // upload person group images
            var person_group_images_path = @"E:\Project\FacePlusPlus\data\PersonGroup";

            if (!Directory.Exists(person_group_images_path))
            {
                Console.WriteLine("person group images directory does not exist");
            }

            // each seperate sub direcotry whitch is in person group images directory has person image files
            var root = new DirectoryInfo(person_group_images_path);
            var facesetStore = CreateFaceSetStore();

            foreach (var subDirectory in root.GetDirectories())
            {
                var person_name = subDirectory.Name;

                foreach (var fileInfo in subDirectory.GetFiles())
                {
                    if (facesetStore.FlatFaceStores.Any(f => f.Image_Name == fileInfo.Name))
                        continue;
                    var detectResponse = client.Face_Detect(fileInfo.FullName);
                    var face = detectResponse.Faces.First();
                    Console.WriteLine("{0}'s face is detected, face token: {1}", person_name, face.Face_Token);
                    var addfaceResponse = client.FaceSet_AddFace(facesetStore.FaceSet_Token, face.Face_Token);
                    Console.WriteLine("upload sucess {0} faces, face set {1} has {2} faces", addfaceResponse.Face_Added, addfaceResponse.FaceSet_Token, addfaceResponse.Face_Count);
                    var faceStore = new FaceStore()
                    {
                        Face_Token = face.Face_Token,
                        Person_Name = person_name,
                        Image_Name = fileInfo.Name
                    };

                    Console.WriteLine("{0}'s face is added, face token: {1}", person_name, faceStore.Face_Token);
                    facesetStore.FlatFaceStores.Add(faceStore);
                }
            }

            SaveFaceSetStore(facesetStore);

            // search persons in an image
            var group_person_image_path = @"E:\Project\FacePlusPlus\data\PersonGroup1\identification1.jpg";
            var searchImageResponse = client.Face_Detect(group_person_image_path);
            foreach (var searchFace in searchImageResponse.Faces)
            {
                var searchResult = client.Face_Search(searchFace.Face_Token, facesetStore.FaceSet_Token);
                var searchFaceToken = searchResult.Results.First().Face_Token;
                var search_person_name = facesetStore.FlatFaceStores.First(f => f.Face_Token == searchFaceToken).Person_Name;
                Console.WriteLine("find person: {0}, confidence: {1}", search_person_name, searchResult.Results.First().Confidence);
            }
        }


        static FaceSetStore CreateFaceSetStore()
        {
            using (var fs = File.Open(store_path, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    using (var sr = new StreamReader(fs))
                    {
                        var facesetStore = JsonConvert.DeserializeObject<FaceSetStore>(sr.ReadToEnd());
                        return facesetStore;
                    }
                }
                else
                {
                    var facesetStore = new FaceSetStore()
                    {
                        Outer_Id = Guid.NewGuid().ToString(),
                        FlatFaceStores = new List<FaceStore>()
                    };
                    facesetStore.FaceSet_Token = client.FaceSet_Create("demo_family", facesetStore.Outer_Id).FaceSet_Token;
                    Console.WriteLine("face set is created, face set outer id: {0}  token: {1}", facesetStore.Outer_Id, facesetStore.FaceSet_Token);
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write(JsonConvert.SerializeObject(facesetStore));
                    }
                    return facesetStore;
                }
            }
        }

        static void SaveFaceSetStore(FaceSetStore facesetStore)
        {
            using (var fs = File.Open(store_path, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(facesetStore));
                }
            }
        }
    }

    class FaceSetStore
    {
        public string FaceSet_Token { get; set; }

        public string Outer_Id { get; set; }

        public IList<FaceStore> FlatFaceStores { get; set; }
    }

    class FaceStore
    {
        public string Face_Token { get; set; }

        public string Outer_Id { get; set; }

        public string Person_Name { get; set; }

        public string Image_Name { get; set; }
    }
}