   using System.Collections.Generic;
   using Newtonsoft.Json;
   using Zenject;

   public abstract class GameSerializer<TService, TData> : IGameSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TService _service;

        public void Serialize(IDictionary<string, string> saveState)
        {
            TData data = Serialize(_service);
            saveState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> loadState)
        {
            if (!loadState.TryGetValue(Key, out string json))
                return;

            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_service, data);
        }

        protected abstract TData Serialize(TService service);
        protected abstract void Deserialize(TService service, TData data);
    }