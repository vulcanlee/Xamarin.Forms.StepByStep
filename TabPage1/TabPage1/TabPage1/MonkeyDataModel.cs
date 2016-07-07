using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabPage1
{
    public class MonkeyDataModel
    {
        public string Name { set; get; }

        public string Family { set; get; }

        public string Subfamily { set; get; }

        public string Tribe { set; get; }

        public string Genus { set; get; }

        public string PhotoUrl { set; get; }
        public Color Color { set; get; }

        public static IList<MonkeyDataModel> All { set; get; }

        static MonkeyDataModel()
        {
            All = new ObservableCollection<MonkeyDataModel> {
                new MonkeyDataModel {
                    Name = "Chimpanzee",
                    Family = "Hominidae",
                    Subfamily = "Homininae",
                    Tribe = "Panini",
                    Genus = "Pan",
                    PhotoUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Schimpanse_Zoo_Leipzig.jpg/640px-Schimpanse_Zoo_Leipzig.jpg",
                    Color = Color.Green
                },
                new MonkeyDataModel {
                    Name = "Orangutan",
                    Family = "Hominidae",
                    Subfamily = "Ponginae",
                    Genus = "Pongo",
                    PhotoUrl = "http://upload.wikimedia.org/wikipedia/commons/b/be/Orang_Utan%2C_Semenggok_Forest_Reserve%2C_Sarawak%2C_Borneo%2C_Malaysia.JPG",
                    Color = Color.Yellow
                },
                new MonkeyDataModel {
                    Name = "Tamarin",
                    Family = "Callitrichidae",
                    Genus = "Saguinus",
                    PhotoUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Tamarin_portrait_2_edit3.jpg/640px-Tamarin_portrait_2_edit3.jpg",
                    Color = Color.Pink
                }
            };
        }
    }
}
