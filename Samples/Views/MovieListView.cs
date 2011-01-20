namespace Samples
{
	using System;
	using System.Collections.ObjectModel;
	using MonoTouch.MVVM;
	using MonoTouch.Dialog;
	using MonoTouch.UIKit;
	using System.Linq;

	public class MovieListView: View<MovieViewModel>
	{
		private View1 _View1 = new View1();
		private View2 _View2 = new View2();

		[Section]
		[Root(DataTemplateType = typeof(MovieElement))]
		public ObservableCollection<MovieView> Movies 
		{
			get;
			set;
		}

		[Section]
		[Root(CellStyle = UITableViewCellStyle.Subtitle)]
		[Caption("Root Address")]
		public AddressView AddressView
		{
			get { return Get(()=>AddressView, new AddressView() {Number = "4751", Street ="Wilshire Blvd", City ="LA", State="CA", Zip ="90010" }); } 
			set { Set(()=>AddressView, value); } 
		}
		
		[Section(Order = 10)]
		public IView DynamicView
		{
			get { return Get(()=>DynamicView, new View1()); }
			set { Set(()=>DynamicView, value); }
		}
		
		[Section]
		public View WebSamples
		{
			get { return Get(()=>WebSamples, new WebSamples()); }
			set { Set(()=>WebSamples, value); }
		}

		[Button]
		[Section(Order = 11)]
		public void ChangeDynamicView()
		{
			if(DynamicView.GetType() == typeof(View1))
				DynamicView = _View2;
			else
				DynamicView = _View1;
		}
		
		[Inline]
		[Section("", "This Address is the same as Root Address above")]
		public AddressView InlineAddress 
		{
			get { return Get(()=>AddressView); } 
			set { Set(()=>AddressView, value); } 
		}
		
		[Section]
		public InterestingView InterestingStuff
		{
			get { return Get(()=>InterestingStuff, new InterestingView()); }
			set { Set(()=>InterestingStuff, value); }
		}

		public MovieListView()
		{
			Movies = new ObservableCollection<MovieView>();
			var dataModel = new MovieDataModel();
			dataModel.Load();

			foreach(var movie in dataModel.Movies)
			{
				Movies.Add(new MovieView() { DataContext = movie });
			}
		}
	}
}

