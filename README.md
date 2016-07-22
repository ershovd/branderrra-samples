# branderrra-samples
Repository for showing exampe of Xamarin.Forms
## Intro ##
This is Xamarin.Forms project for Android and iOS showcasing my development experience. The project structure is mostly standart to usual Xamarin.Forms projects:
* Branderra - PCL library with core functionality and bussiness logic. Within it contains:
  * Branderra/Model - model definitions of the entities used for bussiness logic objects
  * Branderra/View - XAML and code-behind views with customs renders and custom ViewCells
  * Branderra/ViewModel - viewmodel for the correspondant views
  * Branderra/Database - data access layer via SQLLite 
  * Branderra/Serive - miscellaneous files (converters, enums, navigation support)
* Droid - Android-specific implementation 
* Branderra.iOS - project for iOS platform support.

## Most interesing parts to look at ##
* OAUTH authentication and wall posting to 4 social networks: facebook, twiter, instragram, vk.com. Look at [Android](https://github.com/ershovd/branderrra-samples/blob/master/Droid/AndroidAuthenticator.cs) and [iOS implementation](https://github.com/ershovd/branderrra-samples/blob/master/Branderra.IOS/iOSAuthenticator.cs). Client keys\secrets are stripped out due to security.
* Customs renderers for making Label blod, italic, underscore [Core](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/View/Renderers/ExtendedLabel.cs)
with [Android](https://github.com/ershovd/branderrra-samples/blob/master/Droid/Renderers/ExtendedLabelRender.cs) and [iOS implementation](https://github.com/ershovd/branderrra-samples/blob/master/Branderra.IOS/Renderers/ExtendedLabelRenderer.cs)
* Rating control with [5 Star images](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/View/Renderers/StarBehaviorView.xaml.cs) also in [readonly version](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/View/Renderers/StarOnlyLabeView.xaml.cs) 
* Custom [viewcell](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/View/ViewCell/MainFeedViewCell.xaml) with gesture recognizers 
* [Picture taking and selecting photo from gallery](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/ViewModel/PublishPostViewModel.cs#L193)
* [Converter for displaying time relative to Dateime.Now](https://github.com/ershovd/branderrra-samples/blob/master/Branderra/Service/DateToNeatTextValueConverter.cs) in user-friendly fashion (e.g. "few seconds ago", "a minute ago", "1 day ago" etc)
