using System;

namespace TimeCounter_cs
{
    /// <summary>
    /// 日期计算相关相关功能
    /// </summary>
    class Function
    {
        /// <summary>
        /// 日期计算功能选择
        /// </summary>
        public void choose()
        {
            int func = 0;
            DateTime date1;
            DateTime date2;
            TimeSpan diff;

            Console.WriteLine("选择你需要的功能：1.计算与当前日期的天数 2.计算两日期之间的天数 0.退出");
            func = Convert.ToInt32(Console.ReadLine());
            while (func != 0)
            {
                switch (func)
                {
                    case 1:    
                        try
                        {
                            GetDate(out date1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        date2 = DateTime.Now.Date;
                        
                        if (date1 > date2)
                            TimeCount(date1, date2, out diff);
                        else
                            TimeCount(date2, date1, out diff);

                        Display(date1, date2, diff);

                        break;

                    case 2:
                        try
                        {
                            GetDate(out date1);
                            GetDate(out date2);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        if (date1 > date2)
                            TimeCount(date1, date2, out diff);
                        else
                            TimeCount(date2, date1, out diff);

                        Display(date1,date2,diff);

                        break;

                    default:
                        Console.WriteLine("无效输入");

                        break;
                }

                Console.WriteLine("选择你需要的功能：1.计算与当前日期的天数 2.计算两日期之间的天数 0.退出");
                func = Convert.ToInt32(Console.ReadLine());
            }
        }

        /// <summary>
        /// 计算两日期的距离并返回TimeSpan类型的值
        /// </summary>
        public void TimeCount(DateTime date1, DateTime date2,out TimeSpan diff)
        {
            diff = date1 - date2;   
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        public void GetDate(out DateTime date)
        {
            string str;

            Console.WriteLine("\n请输入目标日期：");
            str = Console.ReadLine();
            date = Convert.ToDateTime(str);
        }

        /// <summary>
        /// 显示计算结果
        /// </summary>
        private void Display(DateTime date1,DateTime date2,TimeSpan diff)
        {
            Console.WriteLine(date1.ToString("\nyyyy.MM.dd")+"与"+date2.ToString("yyyy.MM.dd")+"之间相差{0}天\n",diff.Days);
        }
    }

    /// <summary>
    /// 时间计算类
    /// </summary>
    class TimeCounter
    {
        static void Main()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("今天日期为" + dateTime.ToString("yyyy.MM.dd") + '\n');

            Function chooseFunction = new Function();
            chooseFunction.choose();
        }
    }

}
