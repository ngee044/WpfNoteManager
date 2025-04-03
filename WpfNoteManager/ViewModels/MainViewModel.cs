using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using WpfNoteManager.Models;


namespace WpfNoteManager.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<NoteItem> Notes { get; set; }

		private string new_title_;
		public string NewTitle
		{
			get => new_title_;
			set
			{
				if (new_title_ != value)
				{
					new_title_ = value;
					OnPropertyChanged(nameof(NewTitle));
				}
			}
		}

		private string new_content_;
		public string NewContent
		{
			get => new_content_;
			set
			{
				if (new_content_ != value)
				{
					new_content_ = value;
					OnPropertyChanged(nameof(NewContent));
				}
			}
		}

		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand LoadCommand { get; }

		private NoteItem selected_note_;
		public NoteItem SelectedNote
		{
			get => selected_note_;
			set
			{
				if (selected_note_ != value)
				{
					selected_note_ = value;
					OnPropertyChanged(nameof(SelectedNote));
				}
			}
		}

		public MainViewModel()
		{
			Notes = new ObservableCollection<NoteItem>();

			AddCommand = new RelayCommand(AddNote);
			DeleteCommand = new RelayCommand(DeleteNote, CanDeleteNote);
			SaveCommand = new RelayCommand(SaveNotes);
			LoadCommand = new RelayCommand(LoadNotes);
		}

		private void AddNote(object parameter)
		{
			if (string.IsNullOrWhiteSpace(NewTitle)) return;

			var newNote = new NoteItem
			{
				Id = Notes.Count + 1,
				Title = NewTitle,
				Content = NewContent
			};

			Notes.Add(newNote);

			NewTitle = string.Empty;
			NewContent = string.Empty;
		}

		private bool CanDeleteNote(object parameter)
		{
			return SelectedNote != null;
		}

		private void DeleteNote(object parameter)
		{
			if (SelectedNote != null)
			{
				Notes.Remove(SelectedNote);
				SelectedNote = null;
			}
		}

		private void SaveNotes(object parameter)
		{
			string file_path = "notes.txt";
			using (StreamWriter writer = new StreamWriter(file_path, false))
			{
				foreach (var note in Notes)
				{
					writer.WriteLine($"{note.Id},{note.Title},{note.Content}");
				}
			}
		}

		private void LoadNotes(object parameter)
		{
			string file_path = "notes.txt";
			if (!File.Exists(file_path)) return;

			Notes.Clear();

			var lines = File.ReadAllLines(file_path);
			foreach(var line in lines)
			{
				var parts = line.Split(new string[] { "||" }, System.StringSplitOptions.None);
				if (parts.Length == 3)
				{
					if (int.TryParse(parts[0], out int id))
					{
						Notes.Add(new NoteItem
						{
							Id = id,
							Title = parts[1],
							Content = parts[2]
						});
					}
				}
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(
				this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
