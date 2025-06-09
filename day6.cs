using UnityEngine;

public class day6 : MonoBehaviour
{
    //方法重戴
    private static void GetTotalSecond(int minute)
    {
        return minute * 60;
    }
    private static void GetTotalSecond(int minute, int hour)
    {
        return GetTotalSecond(minute + hour * 60);
    }
    private static void GetTotalSecond(int minute, int hour, int day)
    {
        return GetTotalSecond(minute, hour + day * 24);
    }
    //它们是从后开始向前计算的，并且处于一种类似于俄罗斯方块的状态，只有没被消掉的地方才会落下继续进行计算
    //根本上来说最先计算了Day*24的数值，倒推到小时时为Hour*60+day带来的小时数，以此类推


    //递归
    private static int GetFactorial(int num)
    {
        //！递归性能极差所以能不用就不用！
        //优势：有将复杂的问题简单化的好处
        if (num == 1) return 1;
        //不要忘记return和break的退出功能，当它前置时可以轻松地排除条件
        //递归：方法内部又调用自身的过程
        //递归的核心思想：将问题转移给范围缩小的子问题
        return num * GetFactorial(num - 1);
        //递归分为递和归两个步骤，递的入栈会记录下所有可得到的数，在这个示例中时
        //num=3
        //start
        //→3*(3-1)
        //→3*(2*(2-1))
        //→num = 1 return  因为遇见1而停止工作开始归的过程（出栈）
        //→3*(2*(2-1))
        //→3*(2*1)
        //→3*2
        //→6  得出结果，可以理解为一个柜子中的东西从最底层开始放，所以会是最后输出
        //可以将栈理解为一个抽屉，而最后能返回的那个值（在本例子中为num等于1的时候）就是抽屉的最大储存额，等抽屉满了就会开始从顶部开始收拾抽屉
    }
    //递归测试题
    private static int GetFunctionNumber(int num)
    {
        if (num == 1) return 1;

        else if (num % 2 == 0)
            return GetFunctionNumber(num - 1) - num;
        else
            return GetFunctionNumber(num - 1) + num;
    }


    //数组【重点】
    //生成的空间中最初都放着默认值（如0或false）
    static void Main()
    {
        int[] a;//声明
        a = new int[6];
        //通过索引读写每个元素
        a[0] = 1;//将数值1赋值给数组的第1个元素
        a[1] = 2;//将数值1赋值给数组的第2个元素
        a[3] = 3;//将数值1赋值给数组的第3个元素

        for (int i = 0; i < a.Length; i++)//从数组中取数,Length:表示数组的长度（总数）
        {
            console.WriteLine(a[i]);
        }
        //数组练习
        Console.WriteLine("请输入学生总数：");
        int count = int.Parse(Console.ReadLine());
        float[] PointsByStudent = new float[count];

        for (int i = 0; i < PointsByStudent.Length;)
        {
            Console.WriteLine("请输入第{0}个学生的成绩：", i + 1);
            float score = float.Parse(Console.ReadLine());
            if (score >= 0 && score <= 100)
            {
                PointsByStudent[i++] = score;
            }
            else
            {
                Console.WriteLine("输入成绩有误");
            }
        }
        return PointsByStudent;
    }
    //数组练习
    private static float GetMax(float[] array)
    {
        float max = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (max > array[i + 1])
            {
                max = array[i];
            }
            else
            {
                max = array[i + 1];
            }
        }
        return max;
    }
    //数组的便捷写法与foreach
    static void Main()
    {
        string[] array01 = new string[2] { "a", "b" };
        //当你知道数组里的内容时可以直接写入（初始化+赋值）

        string[] array02 = { "a", "b", "c" };
        //可以更加省略（声明+初始化+赋值）

        //int max = GetMax(float[]{5.0,12.0,32.0,4.0});
        //当调用时可以直接进行简便的赋值

        /*
        foreach(元素类型 变量名 in 数组名称)
        {
        变量名 即 数组每个元素
        }
        foreach会从头到尾依次读取所有“数组名称”中的元素
        */
        //局限性：只能读、不能修改元素、只能遍历实现ienumerable接口的集合对象
        string[] array = new string[] { "a", "b", "c" };
        foreach (var item in array01)
        {
            Console.WriteLine(item);
        }
    }
    //数组练习2
    private static int GetDaysOfDates(int year, int month, int day)
    {
        int[] DaysOfLunar = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int[] DaysOfCommon = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int Days = day;
        for (; month > 0; month--)
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                Days = Days + DaysOfLunar[month - 1];
            }
            else
            {
                Days = Days + DaysOfCommon[month - 1];
            }
        }
        return Days;
    }

    //推断类型var，根据所赋值的数据推断出类型
    //适用性：数据类型名称较长，但因为代码可读性太差所以并不适合通篇var

    //声明Array 父类类型 赋值 子类对象
    Array arr01 = new int[2];
    Array arr02 = new double[2];
    Array arr03 = new string[2];

    private static void PrintElement(Array arr)
    {
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
    //因为Array为父类类型可以调用任何类型的对象，即使对象的类型发生变化也无所谓，所以调用时使用Array会比较方便

    //声明object类型 赋值 任意类型
    object o1 = 1;
    object o2 = new float[2];
    object o3 = true;

    //双色球
    //买家购买数字数组名NumberOfBuy
    static Random random = new Random();
    private static void TwoToneBall()
    {
        int RedBallsNumer = new int[6];

        //生成红球
        for (int i = 0; i < 6;)
        {
            int numberRedOfBall = random.Next(1, 34);
            if (Array.IndexOf(c, RedBallsNumer) == -1)
            {
                RedBallsNumer[i++] = numberRedOfBall;
            }
        }
        Array.Sort(RedBallsNumer, 0, 6);//数组名字，起始位置，最终位置

        //买红球
        Console.WriteLine("请输入1~33之间的数字");
        int RedBallsNumberOfBuy = new int[6];
        for (int i = 0; i < 6;)
        {
            int numberOfBuy = Console.ReadLineLine();
            Console.WriteLine("请输入第{0}个红球号码", i);
            if (numberOfBuy < 34 && numberOfBuy > 0 && Array.IndexOf(numberOfBuy, NumberOfBuy) == -1)
            {
                //当数组索引确定有对应对象时返回对象所在位置，如58000中寻找8，输出1，当没有对象时返回-1
                RedBallsNumberOfBuy[i++] = numberOfBuy;
            }
            else
            {
                Console.WriteLine("输入有误");
            }
        }

        int numberBlueOfBall = random.Next(1, 16);
        //买蓝球
        Console.WriteLine("请输入1~16之间的数字");
        int i = Console.ReadLineLine();
        if (NumberBlueOfBuy >= 1 && NumberBlueOfBuy <= 16)
        {
            int NumberBlueOfBuy = i;
        }
        else
        {
            Console.WriteLine("输入有误");
        }
        bool checkBlueBall = CheckBlue(numberBlueOfBall == NumberBlueOfBuy);
        //老师示例：int blueCount = myTicket[6] == randomTicket[6]?1:0;

        //红球有没有中奖
        foreach (var item in RedBallsNumberOfBuy)
        {
            bool CheckRed = new bool[6];
            int Checknumber = 0;
            for (i = 0; i < 6; i++)
            {
                if (Array.IndexOf(RedBallsNumer, number) >= 0)
                    Checknumber++;
            }
        }
        //老师示例（老师的购买数字正在同一组数组）：
        //for(int i = 0;i<6;i++)
        //if(Array.IndexOf(randomTicket,myTicket[0],0,6)>=0)
        //redCount++;

        //生成结果输出不想写了，略！
        /*
        老师示例：
        int Redlevel;
        if (blueCount + redCount == 7)
            level = 1;
        else if (redCount == 6)
            level = 2;
        else if (blueCount + redCount == 6)
            level = 3;
        else if (blueCount + redCount == 5)
            level = 4;
        else if (blueCount + redCount == 4)
            level = 5;
        else if (buleCount == 1)
            level = 6;
        else
            level = 0;
        return level;
        */
    }
}
