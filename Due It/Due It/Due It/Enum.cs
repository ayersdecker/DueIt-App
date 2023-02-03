

namespace Due_It
{
    public enum Priority
    {
        none,       // 0
        low,        // 1
        medium,    // 2
        high        // 3
    }
    public enum CompletionTime
    {
        fifteen,        //0
        thirty,         //1
        fortyFive,      //2
        oneHour,        //3
        oneHourThirty,  //4
        twoHour,        //5
        twoHourThirty,  //6
        threehour,      //7
        fourhour        //8
    }
    public enum RepeatPeriod
    {
        never,
        daily,
        weekly
    }

    //
    // This ENUM is meant to signify different fifteen minute intervals throughout the day according to military time.
    //
    // Key: ...Zero = 0:00  || ...Fift = 0:15  || ...Thir = 0:30  || ...Fort = 0:45 
    //
    //
    public enum TimeSlot
    {
        ZeroFift = 0,       // 0:15 = 0 
        ZeroThir,
        ZeroFort,
        OneZero,            // 1 = 3
        OneFift,
        OneThir,
        OneFort,
        TwoZero,            // 2 = 7
        TwoFift,
        TwoThir,
        TwoFort,
        ThreeZero,          // 3 = 11
        ThreeFift,
        ThreeThir,
        ThreeFort,
        FourZero,           // 4 = 15
        FourFift,
        FourThir,
        FourFort,
        FiveZero,           // 5 = 19
        FiveFift,
        FiveThir,
        FiveFort,
        SixZero,            // 6 = 23
        SixFift,
        SixThir,
        SixFort,
        SevenZero,          // 7 = 27
        SevenFift,
        SevenThir,
        SevenFort,
        EightZero,          // 8 = 31
        EightFift,
        EightThir,
        EightFort,
        NineZero,           // 9 = 35
        NineFift,
        NineThir,
        NineFort,
        TenZero,            // 10 = 39
        TenFift,
        TenThir,
        TenFort,
        ElevenZero,         // 11 = 43
        ElevenFift,
        ElevenThir,
        ElevenFort,
        TweleveZero,        // 12-Noon = 47
        TweleveFift,
        TweleveThir,
        TweleveFort,
        ThirteenZero,       // 13 = 51
        ThirteenFift,
        ThirteenThir,
        ThirteenFort,
        FourteenZero,       // 14 = 55
        FourteenFift,
        FourteenThir,
        FourteenFort,
        FifteenZero,        // 15 = 59
        FifteenFift,
        FifteenThir,
        FifteenFort,
        SixteenZero,        // 16 = 63
        SixteenFift,
        SixteenThir,
        SixteenFort,
        SeventeenZero,      // 17 = 67
        SeventeenFift,
        SeventeenThir,
        SeventeenFort,
        EighteenZero,       // 18 = 71
        EighteenFift,
        EighteenThir,
        EighteenFort,
        NineteenZero,       // 19 = 75
        NineteenFift,
        NineteenThir,
        NineteenFort,
        TwentyZero,         // 20 = 79
        TwentyFift,
        TwentyThir,
        TwentyFort,
        TwentyOneZero,      // 21 = 83
        TwentyOneFift,
        TwentyOneThir,
        TwentyOneFort,
        TwentyTwoZero,      // 22 = 87
        TwentyTwoFift,
        TwentyTwoThir,
        TwentyTwoFort,
        TwentyThreeZero,    // 23 = 91
        TwentyThreeFift,
        TwentyThreeThir,
        TwentyThreeFort,
        TwentyFourZero      // 24-Midnight = 95

    }
}
