﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManualDataBinding.Data;

namespace ManualDataBinding.UI
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : UserControl
    {
        private Note note;
        /// <summary>
        /// Note that will be edited by this control
        /// </summary>
        public Note Note 
        {
            get { return note; } 
            set
            {
                if (note == value) return;
                if (note != null) note.NoteChanged -= OnNoteChange;
                note = value;
                if (note != null)
                {
                    note.NoteChanged += OnNoteChange;
                    OnNoteChange(note, new EventArgs());
                }
            }        
        }

        public NoteEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when the Note changes
        /// </summary>
        /// <param name="sender">The Note instance that is changing</param>
        /// <param name="e">The event arguments describing the event</param>
        public void OnNoteChange(object sender, EventArgs e)
        {
            if (Note == null) return;
            Title.Text = Note.Title;
            Body.Text = Note.Body;            
        }

        /// <summary>
        /// Event handler for when the title changes
        /// </summary>
        /// <param name="sender">The Textbox that changed</param>
        /// <param name="e">The event args</param>
        public void OnTitleChanged(object sender, TextChangedEventArgs e)
        {
            Note.Title = Title.Text;
        }

        /// <summary>
        /// Event handler for when the body changes
        /// </summary>
        /// <param name="sender">The textbox that changed</param>
        /// <param name="e">The event args</param>
        public void OnBodyChanged(object sender, TextChangedEventArgs e)
        {
            Note.Body = Body.Text;
        }
    }
}
