using System;
using MonoMobile.MVVM;
using System.Collections.Generic;
using MonoMobile.MVVM;
using MonoTouch.Foundation;
namespace Samples
{
	public class ElementAPIView : View
	{
	//	public string Text { get { return Get(()=>Text); } set { Set(()=>Text, value); } }
		public string Text { get; set; }
		public string Text2 { get; set; }

		protected IEnumerable<ISection> InitializeSections()
		{
			var sections = new List<ISection>()
			{
				new Section()
				{
				//	new EntryElement("Element API", new Binding(this, "Text", "Value", null)) { Placeholder =  "Add stuff here" }
				}
			};
			
			return sections;
		}

		public ElementAPIView()
		{
			Text = "This";
Text2 = "That";
		}
	}
}

