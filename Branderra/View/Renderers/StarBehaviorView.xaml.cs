using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace Branderra
{
	public partial class StarBehaviorView : ContentView
	{
		public StarBehaviorView()
		{
			InitializeComponent();
		}

		public static readonly BindableProperty IsReadOnlyProperty =
			BindableProperty.Create ("IsReadOnly", typeof(bool), typeof(StarBehaviorView), default(bool));

		public bool IsReadOnly {
			get { return (bool)GetValue(IsReadOnlyProperty); }
			set 
			{
				SetValue(IsReadOnlyProperty, value); 
				UpdateReadOnlyValue(value);
			}
		}

		public static readonly BindableProperty GroupNameProperty =
			BindableProperty.Create("GroupName", typeof(string), typeof(StarBehavior), default(string));

		public string GroupName
		{
			set { SetValue(GroupNameProperty, value); }
			get { return (string)GetValue(GroupNameProperty); }
		}

		public static readonly BindableProperty RatingProperty =
			BindableProperty.Create ("Rating", typeof(int), typeof(StarBehaviorView), default(int));

		public int Rating {
			get { return (int)GetValue(RatingProperty); }
			set 
			{
				UpdateStarsRating(value);
				SetValue(IsReadOnlyProperty, value); 
			}
		}

		void UpdateReadOnlyValue(bool value)
		{
			// HACK: this is needed to store appropriate behaviours
			var behaviuorStars = new List<StarBehavior>() {
				starOne,
				starTwo,
				starThree,
				starFour,
				starFive,
			};

			//behaviuorStars.All(f => f.IsReadOnly = value);
			starFive.IsReadOnly = value;
		}

		void UpdateStarsRating(int ratingValue)
		{
			if (ratingValue > 5)
				throw new ArgumentOutOfRangeException("ratingValue");
		
			var behaviuorStars = new List<StarBehavior>() {
				starOne,
				starTwo,
				starThree,
				starFour,
				starFive,
			};

			// reset rating 
			//behaviuorStars.All(f => f.IsStarred = false);
			starFive.IsStarred = false;

			if (ratingValue == 0)
				return;

			behaviuorStars[ratingValue - 1].IsStarred = true;

			//for (int i = 0; i < ratingValue; i++) {
			//	behaviuorStars[i].IsStarred = true;
			//}

		}
	}
}

