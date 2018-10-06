using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
      
        public List<FormMenu.Account> listOfAccounts = new List<FormMenu.Account>();
        //private string numberOfMobile = "89165751915";
        //private string yourPassword = "M14111997";
        public FormMenu Menu;
        VkApi vkApi = new VkApi();
        private int maxMess;// Счётчик отосланных сообщений

        public struct Id_Name
        {
            public long id;
            public string name;
        }

        public int nextId = 0;// Счётчик следующего id из users

        //public bool Reload { get; private set; }
        public bool reload = false;//Переменная отвечающая за смену id в users
        public int saveCount = 0; //Сохраняем длину listOfFriends,чтобы отслеживать, изменяется он или нет
        public bool Authorize_check(string numberOfMobile, string yourPassword)
        {
            try
            {
                VkNet.Enums.Filters.Settings settings = VkNet.Enums.Filters.Settings.All;
                vkApi.Authorize(new ApiAuthParams
                {
                    Login = numberOfMobile,
                    Password = yourPassword,
                    Settings = settings,
                    ApplicationId = 6661577
                });
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка авторизации! Возможно вы ошиблись в логине или пароле!");
                return false;
            }
        }

        public Form1(List<FormMenu.Account> listOfAccountsMenu)
        {
            listOfAccounts = listOfAccountsMenu;
            InitializeComponent();
        }

        public void GetSendMessage(List<Id_Name> listOfFriendsID)//Расслыка сообщений по списку
        {
            Id_Name structr = new Id_Name();
            for (int i = 0; i < 20; i++)//Отослать 20 сообщений
            {
                Thread.Sleep(1000);
                structr = listOfFriendsID[i];
                structr.name += textBoxGetMess.Text;
                var send = vkApi.Messages.Send(new MessagesSendParams
                {
                    UserId = structr.id,
                    Message = structr.name
                });
            }
        }
        
        public List<Id_Name> GetFriends(ref long id)
        {
           
            List<Id_Name> listOfFriendsID = new List<Id_Name>();//Сформировать список Id-друзей заданного Id
            try
            {
                var users = vkApi.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
                {
                    UserId = id,
                    Fields = ProfileFields.Online | ProfileFields.CanWritePrivateMessage | ProfileFields.City | ProfileFields.BirthDate
                });

                foreach (var friends in users)
                {
                    if (friends.City != null)
                    {
                        if (friends.Online == true && friends.CanWritePrivateMessage == true && friends.City.Title == "Москва")
                        {
                            listFriends.Items.Add(friends.FirstName + " " + friends.LastName + " ");
                        }
                    }
                }
                var date1995 = new DateTime(1995, 10, 5);
                var date2000 = new DateTime(2000, 10, 5);
                foreach (var friends in users)
                {
                    if (friends.City != null && friends.BirthDate != null)
                    {

                        if (DateTime.Parse(friends.BirthDate) > date1995 && DateTime.Parse(friends.BirthDate) < date2000)
                        {
                            if (friends.Online == true && friends.CanWritePrivateMessage == true && friends.City.Title == "Москва")
                            {
                                Id_Name structr = new Id_Name();//Создадим структуру и поместим туда Id и Имя
                                structr.id = friends.Id;
                                structr.name = friends.FirstName;
                                listOfFriendsID.Add(structr);//Запишем структуру в список
                            }
                        }
                    }
                }
                if (listOfFriendsID.Count == 0 || reload == true)
                {
                    nextId++;//Присваеваем следующее id из users
                    id = users[nextId].Id;
                }
                else
                {
                    id = listOfFriendsID[0].id;
                }
                return listOfFriendsID;//Возвращаем список структур
            }
            catch (Exception)
            {
                reload = true;
                nextId++;
                var findId = vkApi.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
                {
                    UserId = Convert.ToInt64(textBoxId.Text)
                });
                id = findId[nextId].Id;
                return listOfFriendsID;
            }
        }
        public List<Id_Name> DeleteListElRepeat(List<Id_Name> LLF)
        {
            int i = 0;
            Id_Name Compare = new Id_Name();
            while (i != LLF.Count)//Прогоняем
              {
                Compare = LLF[LLF.Count - 1];
                LLF.RemoveAll(Pred => Pred.id == LLF[LLF.Count -1].id);//Удаляем все элементы, которые удовлетворяют условию предиката
                LLF.Insert(0, Compare);//Вставляем удалённый элемент
                i++;
               }
            if (LLF.Count == saveCount)
            {
                reload = true;
            }
            else
            {
                reload = false;
            }
            return LLF;
        }
        public List<Id_Name> GetListOfListsOfFriends_LLF(List<Id_Name> LLF, List<Id_Name> listOfFriends)//Создание общего списка из частных и удаление похожих элементов
        {
            saveCount = LLF.Count;
            if (listOfFriends.Count > 0)
            {
                LLF.InsertRange(0, listOfFriends);//Вставляем в общий список часть
                DeleteListElRepeat(LLF);//Удаляет повторяющиеся id
            }
            return LLF;
        }
        internal void ShowModel()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }
        private void recr_button_Click(object sender, EventArgs e)
        {
            Authorize_check(listOfAccounts[0].numberOfMobile, listOfAccounts[0].yourPassword);//Проходим авторизацию
            List<Id_Name> LLF = new List<Id_Name>();
            long FirstId = Convert.ToInt32(textBoxId.Text);
            while (LLF.Count < listOfAccounts.Count*20)
            {
                GetListOfListsOfFriends_LLF(LLF, GetFriends(ref FirstId));//ref должен при каждом обращении к GetFriends давать новый id
            }
            for (int i = 0; i < listOfAccounts.Count; i++)
            {
                nextId = 0;
                Authorize_check(listOfAccounts[i].numberOfMobile, listOfAccounts[i].yourPassword);//Проходим авторизацию на каждой странице
                //GetSendMessage(LLF);//Послать сообщение первым 20 из списка
                LLF.RemoveRange(0, 20);//Удалить первых 20 человек из списка
            }
        }
    }
}
