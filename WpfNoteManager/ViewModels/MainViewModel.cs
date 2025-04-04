using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.IO;
using System.Collections.Generic;
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
			var list_to_save = new List<NoteItem>(Notes);
			string json = JsonConvert.SerializeObject(list_to_save, Formatting.Indented);

			File.WriteAllText("notes.txt", json);
		}

		private void LoadNotes(object parameter)
		{
			if (!File.Exists("notes.txt"))
			{
				return;
			}

			string json = File.ReadAllText("notes.txt");
			var loaded = JsonConvert.DeserializeObject<List<NoteItem>>(json);

			Notes.Clear();
			if (loaded != null)
			{
				foreach (var note in loaded)
				{
					Notes.Add(note);
				}
			}

			if (Notes.Count > 0)
			{
				SelectedNote = Notes[0];
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
