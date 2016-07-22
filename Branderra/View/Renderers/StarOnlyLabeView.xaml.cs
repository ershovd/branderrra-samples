using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Branderra
{
	public partial class StarOnlyLabeView : ContentView
	{
		public StarOnlyLabeView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty RatingProperty =
			BindableProperty.Create ("Rating", typeof (int), typeof (MainFeedViewCell), default (int), BindingMode.TwoWay);

		public int Rating {
			get { return (int)GetValue (RatingProperty); }
			set {
				UpdateRatingValue (value);
				SetValue (RatingProperty, value);
				OnPropertyChanged ();
			}
		}

		void UpdateRatingValue (int ratingVal)
		{
			this.starSelectedOne.IsVisible = ratingVal >= 1;
			this.starSelectedTwo.IsVisible = ratingVal >= 2;
			this.starSelectedThree.IsVisible = ratingVal >= 3;
			this.starSelectedFour.IsVisible = ratingVal >= 4;
			this.starSelectedFive.IsVisible = ratingVal >= 5;
		}
		/*
		public bool StarOne { get; set; }
		public bool StarTwo { get; set; }
		public bool StarThree { get; set; }
		public bool StarFour { get; set; }
		public bool StarFive { get; set; }

		/*
		public static readonly BindableProperty StarOneProperty =
			BindableProperty.Create ("StarOne", typeof (bool), typeof (StarOnlyLabeView), default (bool));

		public bool StarOne {
			get { return (bool)GetValue (StarOneProperty); }
			set { SetValue (StarOneProperty, value); }
		}

		public static readonly BindableProperty StarTwoProperty =
			BindableProperty.Create ("StarTwo", typeof (bool), typeof (StarOnlyLabeView), default (bool));

		public bool StarTwo {
			get { return (bool)GetValue (StarTwoProperty); }
			set { SetValue (StarTwoProperty, value); }
		}

		public static readonly BindableProperty StarThreeProperty =
			BindableProperty.Create ("StarThree", typeof (bool), typeof (StarOnlyLabeView), default (bool));

		public bool StarThree {
			get { return (bool)GetValue (StarThreeProperty); }
			set { SetValue (StarThreeProperty, value); }
		}
		public static readonly BindableProperty StarFourProperty =
			BindableProperty.Create ("StarFour", typeof (bool), typeof (StarOnlyLabeView), default (bool));

		public bool StarFour {
			get { return (bool)GetValue (StarFourProperty); }
			set { SetValue (StarFourProperty, value); }
		}
		public static readonly BindableProperty StarFiveProperty =
			BindableProperty.Create ("StarFive", typeof (bool), typeof (StarOnlyLabeView), default (bool));

		public bool StarFive {
			get { return (bool)GetValue (StarFiveProperty); }
			set { SetValue (StarFiveProperty, value); }		}
		*/
	}
}

