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

namespace VkMyBot
{
 
    public partial class FormMenu : Form
    {
        public struct Account// Структура аккаунта (Логин и пароль)
        {
            public string numberOfMobile;//Логин - номер телефона
            public string yourPassword;//Пароль
        }
        public List<Account> ListOfAccounts = new List<Account>();// Массив аккаунтов из Вконтакте
        public void GetAccArray(string nOfM, string yPass)
        {
            Account Acc = new Account();//Формируем структуру из логина и пароля
            Acc.numberOfMobile = nOfM;
            Acc.yourPassword = yPass;
            ListOfAccounts.Add(Acc);//Добавляем её в массив аккаунтов
            GetListBoxInfo(ListOfAccounts);//Выводим в listbox
            /*var settings = ListListSettings.Properties.Settings.Default;
            var listOfList = settings.ListOfListsOfStrings;
            Settings.Default.FirstUserSetting = listBoxAccounts;
            Settings.Default["ListOfAccountSave"] = listBoxAccounts;//Сохраняем в свойствах
            Settings.Default.Save();*/
        }

        public FormMenu()
        { 
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            
        }
        private void GetListBoxInfo(List<Account> ListOfAccounts)
        {
            listBoxAccounts.Items.Clear();
            for (int i = 0; i < ListOfAccounts.Count; i++)
            {
                listBoxAccounts.Items.Add(ListOfAccounts[i].numberOfMobile.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)// Отправка сообщений
        {
            this.Hide();
            Form1 formMesSend = new Form1(ListOfAccounts);//
            formMesSend.Menu = this; // Установить ссылку
            formMesSend.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Алгоритм добавления друзей
        }

        private void button3_Click(object sender, EventArgs e)// Добавление страницы вк
        {
            FormEntrance formAddPage = new FormEntrance();
            formAddPage.Menu = this; // Установить ссылку
            formAddPage.ShowDialog();
            
        }

        public static implicit operator MainMenu(FormMenu v)
        {
            throw new NotImplementedException();
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (listBoxAccounts.SelectedIndex != -1)
            {
                ListOfAccounts.RemoveAt(listBoxAccounts.SelectedIndex);//Удаляем из listbox
                listBoxAccounts.Items.RemoveAt(listBoxAccounts.SelectedIndex);// Удаляем из массива listBoxAccounts
                /*Settings.Default["ListOfAccountSave"] = listBoxAccounts;//Сохраняем изменения в свойствах
                Settings.Default.Save();*/
            } 
            else
                MessageBox.Show("Необходимо в списке справа выбрать элемент для удаления!");
        }
    }
}
