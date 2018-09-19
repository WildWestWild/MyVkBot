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

namespace VkMyBot
{
    public partial class FormEntrance : Form
    {
        private string numberOfMobile;
        private string yourPassword;
        private ulong appID = 6661577;
        VkApi vkApi = new VkApi();
        public FormEntrance()
        {
            InitializeComponent();
        }

        private void FormEntrance_Load(object sender, EventArgs e)
        {

        }
        public bool Authorize_check(string numberOfMobile, string yourPassword, ulong appID)
        {
            try
            {
                VkNet.Enums.Filters.Settings settings = VkNet.Enums.Filters.Settings.All;
                vkApi.Authorize(new ApiAuthParams
                {
                    Login = numberOfMobile,
                    Password = yourPassword,
                    Settings = settings,
                    ApplicationId = appID
                });
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка авторизации! Возможно вы ошиблись в логине или пароле!");
                return false;
            }
        }

        private void buttonEntrance_Click(object sender, EventArgs e)
        {
            numberOfMobile = textBoxNumber.Text;
            yourPassword = textBoxPassword.Text;
            if (Authorize_check(numberOfMobile, yourPassword, appID))
            {
                this.Hide();
                FormMenu formMenu = new FormMenu();
                formMenu.ShowDialog();
            }
        }
    }
}
