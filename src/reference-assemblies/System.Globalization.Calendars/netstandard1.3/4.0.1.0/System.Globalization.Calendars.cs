[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Globalization.Calendars")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Globalization.Calendars")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Globalization.Calendars")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Globalization
{
    public partial class ChineseLunisolarCalendar : System.Globalization.EastAsianLunisolarCalendar
    {
        public ChineseLunisolarCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int GetEra(System.DateTime time) { throw null; }
    }
    public abstract partial class EastAsianLunisolarCalendar : System.Globalization.Calendar
    {
        internal EastAsianLunisolarCalendar() { }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public int GetCelestialStem(int sexagenaryYear) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public virtual int GetSexagenaryYear(System.DateTime time) { throw null; }
        public int GetTerrestrialBranch(int sexagenaryYear) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class GregorianCalendar : System.Globalization.Calendar
    {
        public GregorianCalendar() { }
        public GregorianCalendar(System.Globalization.GregorianCalendarTypes type) { }
        public virtual System.Globalization.GregorianCalendarTypes CalendarType { get { throw null; } set { } }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public enum GregorianCalendarTypes
    {
        Arabic = 10,
        Localized = 1,
        MiddleEastFrench = 9,
        TransliteratedEnglish = 11,
        TransliteratedFrench = 12,
        USEnglish = 2,
    }
    public partial class HebrewCalendar : System.Globalization.Calendar
    {
        public HebrewCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class HijriCalendar : System.Globalization.Calendar
    {
        public HijriCalendar() { }
        public override int[] Eras { get { throw null; } }
        public int HijriAdjustment { get { throw null; } set { } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class JapaneseCalendar : System.Globalization.Calendar
    {
        public JapaneseCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetWeekOfYear(System.DateTime time, System.Globalization.CalendarWeekRule rule, System.DayOfWeek firstDayOfWeek) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class JapaneseLunisolarCalendar : System.Globalization.EastAsianLunisolarCalendar
    {
        public JapaneseLunisolarCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int GetEra(System.DateTime time) { throw null; }
    }
    public partial class JulianCalendar : System.Globalization.Calendar
    {
        public JulianCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class KoreanCalendar : System.Globalization.Calendar
    {
        public KoreanCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetWeekOfYear(System.DateTime time, System.Globalization.CalendarWeekRule rule, System.DayOfWeek firstDayOfWeek) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class KoreanLunisolarCalendar : System.Globalization.EastAsianLunisolarCalendar
    {
        public KoreanLunisolarCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int GetEra(System.DateTime time) { throw null; }
    }
    public partial class PersianCalendar : System.Globalization.Calendar
    {
        public PersianCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class TaiwanCalendar : System.Globalization.Calendar
    {
        public TaiwanCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetWeekOfYear(System.DateTime time, System.Globalization.CalendarWeekRule rule, System.DayOfWeek firstDayOfWeek) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class TaiwanLunisolarCalendar : System.Globalization.EastAsianLunisolarCalendar
    {
        public TaiwanLunisolarCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int GetEra(System.DateTime time) { throw null; }
    }
    public partial class ThaiBuddhistCalendar : System.Globalization.Calendar
    {
        public ThaiBuddhistCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetWeekOfYear(System.DateTime time, System.Globalization.CalendarWeekRule rule, System.DayOfWeek firstDayOfWeek) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
    public partial class UmAlQuraCalendar : System.Globalization.Calendar
    {
        public UmAlQuraCalendar() { }
        public override int[] Eras { get { throw null; } }
        public override System.DateTime MaxSupportedDateTime { get { throw null; } }
        public override System.DateTime MinSupportedDateTime { get { throw null; } }
        public override int TwoDigitYearMax { get { throw null; } set { } }
        public override System.DateTime AddMonths(System.DateTime time, int months) { throw null; }
        public override System.DateTime AddYears(System.DateTime time, int years) { throw null; }
        public override int GetDayOfMonth(System.DateTime time) { throw null; }
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time) { throw null; }
        public override int GetDayOfYear(System.DateTime time) { throw null; }
        public override int GetDaysInMonth(int year, int month, int era) { throw null; }
        public override int GetDaysInYear(int year, int era) { throw null; }
        public override int GetEra(System.DateTime time) { throw null; }
        public override int GetLeapMonth(int year, int era) { throw null; }
        public override int GetMonth(System.DateTime time) { throw null; }
        public override int GetMonthsInYear(int year, int era) { throw null; }
        public override int GetYear(System.DateTime time) { throw null; }
        public override bool IsLeapDay(int year, int month, int day, int era) { throw null; }
        public override bool IsLeapMonth(int year, int month, int era) { throw null; }
        public override bool IsLeapYear(int year, int era) { throw null; }
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { throw null; }
        public override int ToFourDigitYear(int year) { throw null; }
    }
}
