using A_9_Attributes_Reflection_et.WithoutAttributes;
using A_9_Attributes_Reflection_et.HiddenMemebers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace A_9_Attributes_Reflection_et
{
    public static partial class Lesson
    {
        public static void SerializationExample()
        {
            var song = new WithoutAttributes.Song
            {
                Title = "Случайная",
                Duration = 45,
                Like = false,
                Tags = new string[] {
                    "Pop",
                    "Loboda"
                },
                Album = new WithoutAttributes.Album {
                    Title = "Superstart",
                    Year = 2018
                }
            };


            var serialized = Serializer.Serialize(song);
            Console.WriteLine(serialized);
        }

        public static void CallHiddenMemeberExample()
        {
            var dataToPrint = "Hello World";

            var printer = new Printer();
            printer.Print(dataToPrint);

            var printerType = printer.GetType();

            var method = printerType.GetMethod("PrintColored", 
                BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(printer, new object[] { dataToPrint });
        }

        public static void AttributesSerializationExample()
        {
            var song = new WithBuildInAttributes.Song
            {
                Title = "Случайная",
                Duration = 45,
                Like = false,
                Tags = new string[] {
                    "Pop",
                    "Loboda"
                },
                Album = new WithBuildInAttributes.Album
                {
                    Title = "Superstart",
                    Year = 2018
                }
            };


            var serialized = WithBuildInAttributes.Serializer.Serialize(song);
            Console.WriteLine(serialized);
        }

        public static void CustomAttributesSerializationExample()
        {
            var song = new WithCustomAttributes.Song
            {
                Title = "Случайная",
                Duration = 45,
                Like = false,
                Tags = new string[] {
                    "Pop",
                    "Loboda"
                }
            };


            var serialized = WithCustomAttributes.Serializer.Serialize(song);
            Console.WriteLine(serialized);
        }
    }

    namespace WithoutAttributes
    {
        public class Song
        {
            public int Duration;
            public string Title;
            public string[] Tags;
            public bool? Like;
            public Album Album;

            public void Rate(bool like)
            {
                Like = like;
            }
        }

        public class Album
        {
            public string Title;
            public int Year;
        }

        public static class Serializer
        {
            public static string Serialize<T>(T item)
            {
                var itemType = item.GetType();

                if (itemType.IsArray)
                {
                    return SerializeArray(item as Array);
                }

                bool isPrimitiveType = itemType.IsPrimitive || itemType.IsValueType || (itemType == typeof(string));

                if (isPrimitiveType)
                {
                    return $"'{item?.ToString()}'";
                }

                var serializedItems = new List<string>();
                var fields = itemType.GetFields();

                foreach (var field in fields)
                {
                    var fieldValue = field.GetValue(item);
                    serializedItems.Add($"{field.Name}: {Serialize(fieldValue)}");
                }

                return $"({string.Join(", ", serializedItems)})";
            }

            private static string SerializeArray(Array items)
            {
                var serializedItems = new List<string>();

                foreach (var item in items)
                {
                    serializedItems.Add(Serialize(item));
                }

                return $"[{string.Join(", ", serializedItems)}]";
            }
        }
    }

    namespace WithBuildInAttributes
    {
        [Serializable]
        public class Song
        {            
            public int Duration;
            
            public string Title;
            
            public string[] Tags;

            [NonSerialized]
            public bool? Like;

            [NonSerialized]
            public Album Album;

            public void Rate(bool like)
            {
                Like = like;
            }
        }

        public class Album
        {
            public string Title;
            public int Year;
        }

        public static class Serializer
        {
            public static string Serialize<T>(T item)
            {
                var itemType = item.GetType();
                var hasSerializeableAttribute = 
                    itemType.GetCustomAttribute(typeof(SerializableAttribute)) != null ||
                    (itemType.Attributes & TypeAttributes.Serializable) == TypeAttributes.Serializable;

                if (itemType.IsArray && hasSerializeableAttribute)
                    return SerializeArray(item as Array);

                if (itemType.IsPrimitive || itemType.IsValueType || (itemType == typeof(string)))
                    return $"'{item?.ToString()}'";

                var serializedItems = new List<string>();
                var fields = itemType.GetFields();

                foreach (var field in fields)
                {
                    var fieldValue = field.GetValue(item);
                    var hasNoSerAttribute =
                        field.GetCustomAttribute(typeof(NonSerializedAttribute)) != null;

                    if (!hasNoSerAttribute)
                        serializedItems.Add($"{field.Name}: {Serialize(fieldValue)}");
                }

                return $"({string.Join(", ", serializedItems)})";
            }

            private static string SerializeArray(Array items)
            {
                var serializedItems = new List<string>();

                foreach (var item in items)
                {
                    serializedItems.Add(Serialize(item));
                }

                return $"[{string.Join(", ", serializedItems)}]";
            }
        }
    }

    namespace WithCustomAttributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field)]
        public class CustomSerializableAttribute : System.Attribute
        {
            public string Name { get; set; }

            public CustomSerializableAttribute()
            {
            }

            public CustomSerializableAttribute(string name)
            {
                this.Name = name;
            }
        }        

        [CustomSerializable(name: "audio")]
        public class Song
        {
            [CustomSerializable(name: "seconds")]
            public int Duration;

            [CustomSerializable]
            public string Title;

            public string[] Tags;

            public bool? Like;
        }

        public static class Serializer
        {
            public static string Serialize<T>(T item)
            {
                var itemType = item.GetType();
                var hasSerializeableAttribute =
                    itemType.GetCustomAttribute(typeof(CustomSerializableAttribute)) != null;

                if (itemType.IsArray && hasSerializeableAttribute)
                    return SerializeArray(item as Array);

                if (itemType.IsPrimitive || itemType.IsValueType || (itemType == typeof(string)))
                    return $"'{item?.ToString()}'";

                var serializedItems = new List<string>();
                var fields = itemType.GetFields();

                foreach (var field in fields)
                {
                    var fieldValue = field.GetValue(item);
                    var serAttribute =
                        field.GetCustomAttribute(typeof(CustomSerializableAttribute)) as CustomSerializableAttribute;

                    if (serAttribute != null)
                    {
                        var name = serAttribute.Name ?? field.Name;
                        serializedItems.Add($"{name}: {Serialize(fieldValue)}");
                    }
                        
                }

                return $"({string.Join(", ", serializedItems)})";
            }

            private static string SerializeArray(Array items)
            {
                var serializedItems = new List<string>();

                foreach (var item in items)
                {
                    serializedItems.Add(Serialize(item));
                }

                return $"[{string.Join(", ", serializedItems)}]";
            }
        }
    }

    namespace HiddenMemebers
    {
        public class Printer
        {
            bool hasColoredToner = false;

            public void Print(string data)
            {
                if (hasColoredToner)
                {
                    this.PrintColored(data);
                }
                else
                {
                    this.PrintBW(data);
                }
            }

            private void PrintColored(string data)
            {
                Console.WriteLine($"Printing in color: {data}");
            }

            private void PrintBW(string data)
            {
                Console.WriteLine($"Printing in black and white: {data}");
            }
        }
    }
}
