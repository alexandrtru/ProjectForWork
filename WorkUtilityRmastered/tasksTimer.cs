using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WorkUtiliteRmastered
{
    partial class generalForm
    {
        Timer timer = new Timer();

        void timer_Tick(object sender, EventArgs e)
        {
            System.Console.WriteLine("Tick");
            timer.Interval = (60000 - (System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000));
            if (hasTasks())
            {
                SoundPlayer p = new SoundPlayer(Properties.Resources.missedTask);
                notifyIcon.BalloonTipTitle = "ВНИМАНИЕ!";
                notifyIcon.BalloonTipText = "";
                if (hasMissedTask())
                {
                    notifyIcon.BalloonTipText += "\nВЫ НЕ ВЫПОЛНИЛИ НЕКОТОРЫЕ ДЕЛА!!!.\n";
                }

                if (hasCurrentTasks())
                {
                    notifyIcon.BalloonTipText += "\nК этому времени уже должны были быть выполнены некоторые дела.\n";
                    p.Stream = Properties.Resources.missedTask;
                }

                if (System.DateTime.Now.Minute == 0)
                {

                    if (hasHotTasks())
                    {
                        notifyIcon.BalloonTipText += "\nУ вас важные дела, кликните чтобы посмотреть.\n";
                        p.Stream = Properties.Resources.alarm;
                    }

                    if ((System.DateTime.Now.Hour % 2) == 0)
                    {
                        if (hasSecondTasks())
                        {
                            notifyIcon.BalloonTipText += "\nИмеются дела второго плана, но про них так же не следует забывать.\n";
                            p.Stream = Properties.Resources.alarm;
                        }
                    }

                    if ((System.DateTime.Now.Hour % 3) == 0)
                    {
                        if (hasPermanentTasks())
                        {
                            notifyIcon.BalloonTipText += "\nИмеются перманентные дела.\n";
                            p.Stream = Properties.Resources.alarm;
                        }
                    }
                }
                if (notifyIcon.BalloonTipText != "")
                {
                    notifyIcon.ShowBalloonTip(100000);
                    p.Play();
                    p.Dispose();
                }
            }
        }
        //Проверка есть ли дела вообще?
        private bool hasTasks()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //Есть ли важные дела?
        private bool hasHotTasks()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0 and priory = 0").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //есть ли дела второго плана?
        private bool hasSecondTasks()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0 and priory = 1").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //есть ли перманентные дела?
        private bool hasPermanentTasks()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0 and priory = 2").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //есть ли дела которые нужно выполнить к этому времени?
        private bool hasCurrentTasks()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0 and complete_to = '" + new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, 0).ToString() + "'").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //Есть ли пропущенные дела?
        private bool hasMissedTask()
        {
            try
            {
                if (data.Tables["tasks"].Select("complete = 0 and complete_to < '" + System.DateTime.Now + "'").Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
