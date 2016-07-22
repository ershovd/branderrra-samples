using System;
using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace Branderra
{
	/// <summary>
	/// Converter for neat displaying of periods in time relative to DateTime.Now
	/// </summary>
	public class DateToNeatTextValueConverter  : IValueConverter
	{
		private static readonly Dictionary<int, string> monthInRussian = new Dictionary<int, string>()
		{
			{1, "января"},
			{2, "фераля"},
			{3, "марта"},
			{4, "апреля"},
			{5, "мая"},
			{6, "июня"},
			{7, "июля"},
			{8, "августа"},
			{9, "сентября"},
			{10, "октября"},
			{11, "ноября"},
			{12, "декабря"},
		};

		internal static string CreateFriendlyDateFormat (DateTime dueDate)
		{
			DateTime now = DateTime.Now;
			double daysbetween = (now - dueDate).TotalDays;
			if (Math.Abs (daysbetween) < 1) {
				if (now.Day == dueDate.Day)
					return "Сегодня";
				if (daysbetween > 0)
					return "Вчера";
				if (daysbetween < 0)
					return "Завтра";
			}
			bool sameYear = now.Year - dueDate.Year == 0;
			if (sameYear) 
			{
				if (!monthInRussian.ContainsKey (dueDate.Month)) throw new InvalidOperationException ();
				return string.Format ("{0} {1}", dueDate.Day.ToString (CultureInfo.InvariantCulture), monthInRussian [dueDate.Month]);
			}
			else 
			{
				return dueDate.ToString("dd.MM.yyyy", CultureInfo.CurrentCulture);  //CreateSpecificCulture ("ru-RU"));
			}
		}

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return CreateFriendlyDateFormat((DateTime)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}

