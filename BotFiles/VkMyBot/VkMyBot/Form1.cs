using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkMyBot.Properties;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkMyBot
{
    public partial class Form1 : Form
    {
        VkApi vkApi = new VkApi();
        private int maxMess;// Счётчик отосланных сообщений

        public struct Id_Name
        {
            public long id;
            public string name;
        }

        private int MaxMess
        {
            get
            {
                return maxMess;
            }
            set
            {
                if (MaxMess <= 20)
                {
                    maxMess = value;
                }
                else
                {
                    MessageBox.Show("Больше сообщений отослать невозможно");
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

        }

        public int GetSendMessage(List<Id_Name> listOfFriendsID)//Расслыка сообщений по списку
        {
            for (int i = 0; i < listOfFriendsID.Count(); i++)
            {
                Id_Name structr = new Id_Name();
                structr = listOfFriendsID[i];
                structr.name += textBoxGetMess.Text;
                var send = vkApi.Messages.Send(new MessagesSendParams
                {
                    UserId = structr.id,
                    Message = structr.name
                });
                MaxMess++;
            }
            return MaxMess;
        }
        
        public List<Id_Name> GetFriends(ref long id)
        {
            var users = vkApi.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = id,
                Fields = ProfileFields.Online | ProfileFields.CanWritePrivateMessage | ProfileFields.City
            });
            
            foreach (var friends in users)
            {
                if (friends.Online == true && friends.CanWritePrivateMessage == true && friends.City.Title == "Москва")
                {
                    
                    listFriends.Items.Add(friends.FirstName + " " + friends.LastName + " ");
                }
            }

            List<Id_Name> listOfFriendsID = new List<Id_Name>();//Сформировать список Id-друзей заданного Id
            foreach (var friends in users)
            {
                if (friends.Online == true && friends.CanWritePrivateMessage == true && friends.City.Title == "Москва")
                {
                    Id_Name structr = new Id_Name();//Создадим структуру и поместим туда Id и Имя
                    structr.id = friends.Id;
                    structr.name = friends.FirstName;
                    listOfFriendsID.Add(structr);//Запишем структуру в список
                }
            }
            id = listOfFriendsID[0].id;
            return listOfFriendsID;//Возвращаем список структур

            //GetSendMessage(listOfFriendsID);
        }
        public List<Id_Name> DeleteListElRepeat(List<Id_Name> LLF)
        {
            int i = 0;

            while (i != LLF.Count)
            {
                Id_Name Compare = new Id_Name();
                Compare = LLF[i];//Присваиваем перменной значение LLF
                LLF.RemoveAll(Pred => Compare.id == LLF[i].id);//Удаляем все элементы, которые удовлетворяют условию предиката
                LLF.Add(Compare);//Добавляем в список удалённый элемент, чтобы он находился там в единственном количестве
                i++;
            }
            return LLF;
        }
        public List<Id_Name> GetListOfListsOfFriends_LLF(List<Id_Name> LLF, List<Id_Name> listOfFriends)//Создание общего списка из частных и удаление похожих элементов
        {

            LLF.InsertRange(0, listOfFriends);//Вставляем в общий список часть
            DeleteListElRepeat(LLF);
            //id = LLF[0].id;
            return LLF;
        }
        internal void ShowModel()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            long FirstId = Convert.ToInt32(textBoxId.Text);
            List<Id_Name> LLF = new List<Id_Name>();
            do
            {
                GetListOfListsOfFriends_LLF(LLF, GetFriends(ref FirstId));//ref должен при каждом обращении к GetFriends давать новый id
                MaxMess += GetSendMessage(LLF);
            } while (maxMess <= 20);
                


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
