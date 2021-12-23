using System.Collections.Generic;
using Newtonsoft.Json;

namespace InvitesApp.IO
{
    partial class User
    {
        public void GetStory()
        {
            TagsSt = TagsStory == null ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(TagsStory);
        }

        public void SaveSt()
        {
            TagsStory = JsonConvert.SerializeObject(TagsSt);
        }

        public string UIName { get => $"Добро пожаловать, {Name}"; }

        public List<string> TagsSt;
    }
}
