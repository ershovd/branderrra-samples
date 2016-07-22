using System;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using XLabs.Ioc;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Device;
using System.Threading.Tasks;
using System.Linq;

namespace Branderra
{
	public class PublishPostViewModel : BranderraViewModelBase
	{
		private MediaPickerHelper mediaHelper;

		public PublishPostViewModel (IServerAPIProvider service, INavigationService navigationService) : base (service, navigationService)
		{
			Title = "Новый пост";
			PhotoSource = ImageSource.FromFile ("profile_image.png");
			PhotoDescriptText = "";
			mediaHelper = new MediaPickerHelper ();

			// TODO: generate list based on selection
			this.CategoryItems = new ObservableCollection<string> (service.GetAllCategories ().Select (f => f.Title));
			this.TypesItems = new ObservableCollection<string> (service.GetBrandsByCategoryId (Guid.Empty).Select (f => f.Title));
			this.BrandItems = new ObservableCollection<string> (service.GetBrandsByCategoryAndBrandId (Guid.Empty, Guid.Empty).Select (f => f.Title));
			mediaHelper.Setup ();
		}

		string photoDescriptText;
		public string PhotoDescriptText {
			get {
				return photoDescriptText;
			}
			set {
				if (photoDescriptText != value) {
					photoDescriptText = value;
					RaisePropertyChanged ();
				}
			}
		}

		private ImageSource photoSource;
		public ImageSource PhotoSource {
			get {
				return photoSource;
			}
			set {
				if (photoSource != value) {
					photoSource = value;
					RaisePropertyChanged ();
				}
			}
		}

		private ObservableCollection<string> categoryItems;
		public ObservableCollection<string> CategoryItems {
			get {
				return categoryItems;
			}
			set {
				if (categoryItems != value) {
					categoryItems = value;
					RaisePropertyChanged ();
				}
			}
		}

		private int categorySelectedIndex;
		public int CategorySelectedIndex {
			get {
				return categorySelectedIndex;
			}
			set {
				if (categorySelectedIndex != value) {
					categorySelectedIndex = value;
					RaisePropertyChanged ();
				}
			}
		}

		private ObservableCollection<string> typesItems;
		public ObservableCollection<string> TypesItems {
			get {
				return typesItems;
			}
			set {
				if (typesItems != value) {
					typesItems = value;
					RaisePropertyChanged ();
				}
			}
		}

		private int typesSelectedIndex;
		public int TypesSelectedIndex {
			get {
				return typesSelectedIndex;
			}
			set {
				if (typesSelectedIndex != value) {
					typesSelectedIndex = value;
					RaisePropertyChanged ();
				}
			}
		}

		private ObservableCollection<string> brandItems;
		public ObservableCollection<string> BrandItems {
			get {
				return brandItems;
			}
			set {
				if (brandItems != value) {
					brandItems = value;
					RaisePropertyChanged ();
				}
			}
		}

		private int brandSelectedIndex;
		public int BrandSelectedIndex {
			get {
				return brandSelectedIndex;
			}
			set {
				if (brandSelectedIndex != value) {
					brandSelectedIndex = value;
					RaisePropertyChanged ();
				}
			}
		}

		private string _status;
		public string Status {
			get { return _status; }
			private set {
				if (_status != value) {
					_status = value;
					RaisePropertyChanged ();
				}
			}
		}




		#region Commands
		public Command LoadPhotoCommand {
			get {
				return new Command (async () => {
					await mediaHelper.TakePicture ();
					if (string.IsNullOrEmpty (mediaHelper.Status))
					{
						PhotoSource = mediaHelper.PhotoSource; 
					}
					else
					{
						// TODO: add error handlingg
					} }, () => true);
			}
		}

		public Command SelectPictureCommand {
			get {
				return new Command (async () => {
					await mediaHelper.SelectPicture ();
					if (string.IsNullOrEmpty (mediaHelper.Status)) 
					{ 
						PhotoSource = mediaHelper.PhotoSource; 
					}
					else 
					{
						// TODO: add error handling
					} }, () => true);
			}
		}

		public RelayCommand PublishPostCommand {
			get { return new RelayCommand (PusblishPostInternal); }
		}

		private void PusblishPostInternal ()
		{
			//
		}

		#endregion
	}

	public class MediaPickerHelper
	{
		/// <summary>
		/// The _scheduler.
		/// </summary>
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext ();

		private IMediaPicker _mediaPicker;

		/// <summary>
		/// Setups this instance.
		/// </summary>
		public void Setup ()
		{
			if (_mediaPicker != null) return;


			var device = Resolver.Resolve<IDevice> ();

			////RM: hack for working on windows phone? 
			_mediaPicker = DependencyService.Get<IMediaPicker> () ?? device.MediaPicker;
		}
		
			public ImageSource PhotoSource {	get; set; }
			public string Status { get; set; }

		/// <summary>
		/// Takes the picture.
		/// </summary>
		/// <returns>Take Picture Task.</returns>
		public async Task TakePicture ()
		{
			Setup ();
			Status = string.Empty;
			PhotoSource = null;

			await _mediaPicker.TakePhotoAsync (new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith (t => {
				if (t.IsFaulted) {
					Status = t.Exception.InnerException.ToString ();
				} else if (t.IsCanceled) {
					Status = "Canceled";
				} else {
					var mediaFile = t.Result;

					PhotoSource = ImageSource.FromStream (() => mediaFile.Source);
				}
			}, _scheduler);
		}

		/// <summary>
		/// Selects the picture.
		/// </summary>
		/// <returns>Select Picture Task.</returns>
		public async Task SelectPicture ()
		{
			Setup ();
			Status = string.Empty;
			PhotoSource = null;
			try {
				await _mediaPicker.SelectPhotoAsync (new CameraMediaStorageOptions {
					DefaultCamera = CameraDevice.Front,
					MaxPixelDimension = 400
				}).ContinueWith(t => {
					if (t.IsFaulted)
					{
						Status = t.Exception.InnerException.ToString ();
					}
					if (t.IsCanceled)
					{
						Status = "Canceled";
					}
					if (t.IsCompleted)
					{
						var mediaFile = t.Result;
						PhotoSource = ImageSource.FromStream (() => mediaFile.Source);
					}
				}, _scheduler);

			} catch (System.Exception ex) {
				Status = ex.Message;
			}
		}
	}
}
