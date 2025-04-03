using System;
using System.ComponentModel;

namespace WpfNoteManager.Models
{
    public class NoteItem : INotifyPropertyChanged
	{
		private string title_;
		private string content_;

		public int Id { get; set; }
		public string Title
		{
			get => title_;
			set
			{
				if (title_ != value)
				{
					title_ = value;
					OnPropertyChanged(nameof(Title));
				}
			}
		}

		public string Content
		{
			get => content_;
			set
			{
				if (content_ != value)
				{
					content_ = value;
					OnPropertyChanged(nameof(Content));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
