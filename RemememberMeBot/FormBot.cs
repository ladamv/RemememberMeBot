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
        private bool botWork = false;
        private DataManager dataManager;
        private List<WordAndTranslation> watList;

        private Random rnd;
        private int firstIndex, secondIndex;
        private string firstWord, secondWord;
        private string rightEnglishWord;
        private bool checkAnswer;

        public FormBot()
        {
            InitializeComponent();
        }

        private void buttonStartBot_Click(object sender, EventArgs e)
        {
            if (botWork==false)
            {
                backgroundWorkerBot.RunWorkerAsync();
                MessageBox.Show("Бот запущен");
                botWork = true;
            }
            else
            {
                MessageBox.Show("Бот уже работает!!!");
            }
        }

        private async void backgroundWorkerBot_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                TelegramBotClient botClient = new  TelegramBotClient(token);
                await botClient.SetWebhookAsync("");
                int offset = 0;
                while (true)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    Update[] updates = await botClient.GetUpdatesAsync(offset);
                    foreach (Update update in updates)
                    {
                        Telegram.Bot.Types.Message message = update.Message;
                        if (message.Type == MessageType.TextMessage)
                        {
                            string answer = "команда неизвестна";
                            if (checkAnswer == false)
                            {
                                switch (message.Text)
                                {
                                    case "/hello":
                                        answer = "Hey there! Let's start with the next word.";
                                        await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                                        break;

                                    case "/bye":
                                        answer = "See you later";
                                        await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                                        break;

                                    case "/newword":

                                        firstIndex = rnd.Next(0, watList.Count);
                                        do
                                        {
                                            secondIndex = rnd.Next(0, watList.Count);
                                        } while (secondIndex == firstIndex);

                                        rightEnglishWord = watList[firstIndex].EnglishWord;

                                        if (rnd.Next(0, 1000) > 500)
                                        {
                                            firstWord = watList[firstIndex].EnglishWord;
                                            secondWord = watList[secondIndex].EnglishWord;
                                        }
                                        else
                                        {
                                            firstWord = watList[secondIndex].EnglishWord;
                                            secondWord = watList[firstIndex].EnglishWord;
                                        }

                                        var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(
                                            keyboardRow:
                                            new KeyboardButton[]
                                            {
                                                new KeyboardButton(firstWord),
                                                new KeyboardButton(secondWord)
                                            },
                                            resizeKeyboard: true
                                        );
                                        checkAnswer = true;
                                        await botClient.SendTextMessageAsync(message.Chat.Id,
                                            watList[firstIndex].RussianWord, replyMarkup: keyboard);
                                        break;

                                        default:
                                            await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                                        break;
                                            
                                }
                            }
                            else
                            {
                                if (message.Text == rightEnglishWord)
                                {
                                    answer = "all correct";
                                    await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                                }
                                else
                                {
                                    answer = "wrong answer";
                                    await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                                }
                                checkAnswer = false;
                            }

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

        private void buttonStopBot_Click(object sender, EventArgs e)
        {
            if (botWork == true)
            {
                backgroundWorkerBot.CancelAsync();
                MessageBox.Show("Бот остановлен");
                botWork = false;
            }
            else
            {
                MessageBox.Show("Бот уже остановлен!!!");
            }
        }

        private void buttonStartDictionary_Click(object sender, EventArgs e)
        {
            new FormDictionary().ShowDialog();
            watList = dataManager.SelectAllFromTableWaT();
        }

        private void FormBot_Load(object sender, EventArgs e)
        {
            dataManager = DataManager.GetInstance();
            dataManager.CreateTableWaT();
            watList = dataManager.SelectAllFromTableWaT();

            rnd = new Random();
            firstIndex = -1;
            secondIndex = -1;
            rightEnglishWord=String.Empty;
            checkAnswer = false;

        }
    }
}
