using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;

namespace RemememberMeBot
{
    public partial class FormBot : Form
    {
        private const string token = "421289239:AAFc5jaQI4fXZ2k-G-10rahOm4Pqc5moNss";

        public FormBot()
        {
            InitializeComponent();
        }

        private void buttonStartBot_Click(object sender, EventArgs e)
        {
            backgroundWorkerBot.RunWorkerAsync();
        }

        private async void backgroundWorkerBot_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TelegramBotClient botClient = new  TelegramBotClient(token);
                await botClient.SetWebhookAsync("");
                int offset = 0;
                while (true)
                {
                    Update[] updates = await botClient.GetUpdatesAsync(offset);
                    foreach (Update update in updates)
                    {
                        Telegram.Bot.Types.Message message = update.Message;
                        if (message.Type == MessageType.TextMessage)
                        {
                            string answer = "команда неизвестна";
                            switch (message.Text)
                            {
                                case "/hello":
                                    answer = "Hey there! Let's start with the next word.";
                                    break;
                                case "/bye":
                                    answer = "See you later";
                                    break;
                            }
                            await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                        }
                        offset = update.Id + 1;
                    }
                }

            }
            catch (ApiRequestException exception)
            {
                MessageBox.Show("Ошибка: " + exception.Message);
            }
        }
    }
}
