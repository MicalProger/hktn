using System.Collections.Generic;

namespace InvitesApp.IO
{
    partial class User
    {
        public string UIName { get => $"Добро пожаловать, {Name}"; }

        public List<string> TagsSt
        {
            get
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(TagsStory);
            }
            set
            {
                TagsStory = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }
    }
}
