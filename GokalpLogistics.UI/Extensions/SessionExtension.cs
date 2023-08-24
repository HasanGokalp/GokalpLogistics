using Newtonsoft.Json;

namespace GokalpLogistics.UI.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object? value)
        {
            var x = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });

            session.SetString(key, x);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
