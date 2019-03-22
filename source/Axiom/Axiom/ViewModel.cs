﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2019 Matt McManis
http://github.com/MattMcManis/Axiom
http://axiomui.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
// Disable XML Comment warnings
#pragma warning disable 1591
#pragma warning disable 1587
#pragma warning disable 1570

namespace Axiom
{
    public class ViewModel : INotifyPropertyChanged
    {
        //private MainWindow mainwindow = (MainWindow)System.Windows.Application.Current.MainWindow;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string prop)
        {
            //PropertyChangedEventHandler handler = PropertyChanged;
            //handler(this, new PropertyChangedEventArgs(name));

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ViewModel()
        {
            // -------------------------
            // ComboBox Defaults
            // -------------------------
            // Main
            Preset_IsEnabled = true;
            Preset_SelectedItem = Preset_Items.FirstOrDefault();

            // Format
            Format_Container_SelectedItem = "webm";
            //Format_Container_SelectedItem = Format_Container_Items.FirstOrDefault();
            //Format_Container_SelectedIndex = 1;
            Format_MediaType_SelectedItem = "Video";
            Video_EncodeSpeed_SelectedItem = "Medium";
            Format_HWAccel_SelectedItem = "off";
            Format_Cut_SelectedItem = "No";

            // Video
            Video_Codec_SelectedItem = "VP8";
            Video_Quality_SelectedItem = "Auto";
            Video_VBR_IsChecked = false;
            Video_Pass_SelectedItem = "2 Pass";
            Video_PixelFormat_SelectedItem = "auto";
            Video_FPS_SelectedItem = "auto";
            Video_Speed_SelectedItem = "auto";
            Video_Optimize_SelectedItem = "None";
            Video_Optimize_Tune_SelectedItem = "none";
            Video_Optimize_Profile_SelectedItem = "none";
            Video_Optimize_Level_SelectedItem = "none";
            Video_Scale_SelectedItem = "Source";
            Video_AspectRatio_SelectedItem = "auto";
            Video_ScalingAlgorithm_SelectedItem = "default";

            // Subtitle
            Subtitle_Codec_SelectedItem = "None";
            Subtitle_Stream_SelectedItem = "none";

            // Audio
            Audio_Codec_SelectedItem = "Vorbis";
            Audio_Stream_SelectedItem = "1";
            Audio_Channel_SelectedItem = "Source";
            Audio_Quality_SelectedItem = "Auto";
            Audio_SampleRate_SelectedItem = "auto";
            Audio_BitDepth_SelectedItem = "auto";

            // Configure
            Theme_SelectedItem = "Axiom";
            Threads_SelectedItem = "optimal";
        }

        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Tools
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------
        // CMD Window Keep - Toggle
        // --------------------------------------------------
        private bool _CMDWindowKeep_IsChecked;
        public bool CMDWindowKeep_IsChecked
        {
            get { return _CMDWindowKeep_IsChecked; }
            set
            {
                if (_CMDWindowKeep_IsChecked != value)
                {
                    _CMDWindowKeep_IsChecked = value;
                    OnPropertyChanged("CMDWindowKeep_IsChecked");
                }
            }
        }

        // --------------------------------------------------
        // Auto Sort Script - Toggle
        // --------------------------------------------------
        private bool _AutoSortScript_IsChecked;
        public bool AutoSortScript_IsChecked
        {
            get { return _AutoSortScript_IsChecked; }
            set
            {
                if (_AutoSortScript_IsChecked != value)
                {
                    _AutoSortScript_IsChecked = value;
                    OnPropertyChanged("AutoSortScript_IsChecked");
                }
            }
        }


        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Input
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------
        // Input - TextBox
        // --------------------------------------------------
        // Text
        private string _Input_Text = string.Empty;
        public string Input_Text
        {
            get { return _Input_Text; }
            set
            {
                if (_Input_Text == value)
                {
                    return;
                }

                _Input_Text = value;
                OnPropertyChanged("Input_Text");
            }
        }

        // --------------------------------------------------
        // Output - TextBox
        // --------------------------------------------------
        // Text
        private string _Output_Text = string.Empty;
        public string Output_Text
        {
            get { return _Output_Text; }
            set
            {
                if (_Output_Text == value)
                {
                    return;
                }

                _Output_Text = value;
                OnPropertyChanged("Output_Text");
            }
        }

        // --------------------------------------------------
        // Batch - Toggle
        // --------------------------------------------------
        // Checked
        private bool _Batch_IsChecked;
        public bool Batch_IsChecked
        {
            get { return _Batch_IsChecked; }
            set
            {
                if (_Batch_IsChecked != value)
                {
                    _Batch_IsChecked = value;
                    OnPropertyChanged("Batch_IsChecked");
                }
            }
        }

        // --------------------------------------------------
        // Batch Extension - TextBox
        // --------------------------------------------------
        // Text
        private string _BatchExtension_Text = "extension";
        public string BatchExtension_Text
        {
            get { return _BatchExtension_Text; }
            set
            {
                if (_BatchExtension_Text == value)
                {
                    return;
                }

                _BatchExtension_Text = value;
                OnPropertyChanged("BatchExtension_Text");
            }
        }
        // Enabled
        private bool _BatchExtension_IsEnabled { get; set; }
        public bool BatchExtension_IsEnabled
        {
            get { return _BatchExtension_IsEnabled; }
            set
            {
                if (_BatchExtension_IsEnabled == value)
                {
                    return;
                }

                _BatchExtension_IsEnabled = value;
                OnPropertyChanged("BatchExtension_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Script View
        // --------------------------------------------------
        // FlowDocument
        private FlowDocument _ScriptView_FlowDocument;
        public FlowDocument ScriptView_FlowDocument
        {
            get { return _ScriptView_FlowDocument; }
            set
            {
                if (_ScriptView_FlowDocument == value)
                {
                    return;
                }

                _ScriptView_FlowDocument = value;
                OnPropertyChanged("ScriptView_FlowDocument");
            }
        }

        // Paragraph
        private Paragraph _ScriptView_Paragraph;
        public Paragraph ScriptView_Paragraph
        {
            get { return _ScriptView_Paragraph; }
            set
            {
                if (_ScriptView_Paragraph == value)
                {
                    return;
                }

                _ScriptView_Paragraph = value;
                OnPropertyChanged("ScriptView_Paragraph");
            }
        }

        // Text
        private string _ScriptView_Text;
        public string ScriptView_Text
        {
            get { return _ScriptView_Text; }
            set
            {
                if (value != _ScriptView_Text)
                {
                    _ScriptView_Text = value;
                    OnPropertyChanged("ScriptView_Text");
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Settings
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------
        // Preset
        // --------------------------------------------------
        // Items Source
        private List<string> _Preset_Items = new List<string>()
        {
            "Preset",
            "Default",
            "DVD",
            "Blu-ray",
            "HEVC",
            "HD Video",
            "SD Video",
            "HTML5",
            "Android",
            "iOS",
            "iTunes",
            "MP3 HQ",
            "PS3",
            "PS4",
            "Xbox 360",
            "Xbox One",
            "Debug"
        };
        public List<string> Preset_Items
        {
            get { return _Preset_Items; }
            set
            {
                _Preset_Items = value;
                OnPropertyChanged("Preset_Items");
            }
        }

        // Selected Index
        private int _Preset_SelectedIndex { get; set; }
        public int Preset_SelectedIndex
        {
            get { return _Preset_SelectedIndex; }
            set
            {
                if (_Preset_SelectedIndex == value)
                {
                    return;
                }

                _Preset_SelectedIndex = value;
                OnPropertyChanged("Preset_SelectedIndex");
            }
        }

        // Selected Item
        private string _Preset_SelectedItem { get; set; }
        public string Preset_SelectedItem
        {
            get { return _Preset_SelectedItem; }
            set
            {
                if (_Preset_SelectedItem == value)
                {
                    return;
                }

                _Preset_SelectedItem = value;
                OnPropertyChanged("Preset_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Preset_IsEnabled { get; set; }
        public bool Preset_IsEnabled
        {
            get { return _Preset_IsEnabled; }
            set
            {
                if (_Preset_IsEnabled == value)
                {
                    return;
                }

                _Preset_IsEnabled = value;
                OnPropertyChanged("Preset_IsEnabled");
            }
        }

        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Format
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------
        // Containers
        // --------------------------------------------------
        // Items Source
        public class FormatContainer
        {
            public string Name { get; set; }
            public bool Category { get; set; }
        }

        public List<FormatContainer> _Format_Container_Items = new List<FormatContainer>()
        {
            new FormatContainer() { Name = "Video", Category = true  },
            new FormatContainer() { Name = "webm",  Category = false },
            new FormatContainer() { Name = "mp4",   Category = false },
            new FormatContainer() { Name = "mkv",   Category = false },
            new FormatContainer() { Name = "mpg",   Category = false },
            new FormatContainer() { Name = "avi",   Category = false },
            new FormatContainer() { Name = "ogv",   Category = false },

            new FormatContainer() { Name = "Audio", Category = true  },
            new FormatContainer() { Name = "mp3",   Category = false },
            new FormatContainer() { Name = "m4a",   Category = false },
            new FormatContainer() { Name = "ogg",   Category = false },
            new FormatContainer() { Name = "flac",  Category = false },
            new FormatContainer() { Name = "wav",   Category = false },

            new FormatContainer() { Name = "Image", Category = true  },
            new FormatContainer() { Name = "jpg",   Category = false },
            new FormatContainer() { Name = "png",   Category = false },
            new FormatContainer() { Name = "webp",  Category = false },
        };

        public List<FormatContainer> Format_Container_Items
        {
            get { return _Format_Container_Items; }
            set
            {
                _Format_Container_Items = value;
                OnPropertyChanged("Format_Container_Items");
            }
        }

        private int _Format_Container_SelectedIndex { get; set; }
        public int Format_Container_SelectedIndex
        {
            get { return _Format_Container_SelectedIndex; }
            set
            {
                //if (_Format_Container_SelectedIndex != value)
                //{
                //    _Format_Container_SelectedIndex = value;
                //    OnPropertyChanged("Format_Container_SelectedIndex");
                //}
                if (_Format_Container_SelectedIndex == value)
                {
                    return;
                }

                _Format_Container_SelectedIndex = value;
                OnPropertyChanged("Format_Container_SelectedIndex");
            }
        }

        // Selected Item
        //public string Format_Container_SelectedItem { get; set; }
        private string _Format_Container_SelectedItem { get; set; }
        public string Format_Container_SelectedItem
        {
            get { return _Format_Container_SelectedItem; }
            set
            {
                if (_Format_Container_SelectedItem == value)
                {
                    return;
                }

                _Format_Container_SelectedItem = value;
                OnPropertyChanged("Format_Container_SelectedItem");
            }
        }


        // --------------------------------------------------
        // Media Type
        // --------------------------------------------------
        // Items Source
        private List<string> _Format_MediaType_Items = new List<string>()
        {
            "Video",
            "Audio",
            "Image",
            "Sequence"
        };
        public List<string> Format_MediaType_Items
        {
            get { return _Format_MediaType_Items; }
            set
            {
                _Format_MediaType_Items = value;
                OnPropertyChanged("Format_MediaType_Items");
            }
        }

        // Selected Index
        private int _Format_MediaType_SelectedIndex { get; set; }
        public int Format_MediaType_SelectedIndex
        {
            get { return _Format_MediaType_SelectedIndex; }
            set
            {
                if (_Format_MediaType_SelectedIndex == value)
                {
                    return;
                }

                _Format_MediaType_SelectedIndex = value;
                OnPropertyChanged("Format_MediaType_SelectedIndex");
            }
        }

        // Selected Item
        private string _Format_MediaType_SelectedItem { get; set; }
        public string Format_MediaType_SelectedItem
        {
            get { return _Format_MediaType_SelectedItem; }
            set
            {
                if (_Format_MediaType_SelectedItem == value)
                {
                    return;
                }

                _Format_MediaType_SelectedItem = value;
                OnPropertyChanged("Format_MediaType_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Format_MediaType_IsEnabled = true;
        public bool Format_MediaType_IsEnabled
        {
            get { return _Format_MediaType_IsEnabled; }
            set
            {
                if (_Format_MediaType_IsEnabled == value)
                {
                    return;
                }

                _Format_MediaType_IsEnabled = value;
                OnPropertyChanged("Format_MediaType_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Encode Speed
        // --------------------------------------------------
        // Items Source
        public class VideoEncodeSpeed
        {
            public string Name { get; set; }
            public string Command { get; set; }
            public string Command_2Pass { get; set; }
        }
        public List<VideoEncodeSpeed> _Video_EncodeSpeed_Items = new List<VideoEncodeSpeed>();
        public List<VideoEncodeSpeed> Video_EncodeSpeed_Items
        {
            get { return _Video_EncodeSpeed_Items; }
            set
            {
                _Video_EncodeSpeed_Items = value;
                OnPropertyChanged("Video_EncodeSpeed_Items");
            }
        }

        // Selected Index
        private int _Video_EncodeSpeed_SelectedIndex { get; set; }
        public int Video_EncodeSpeed_SelectedIndex
        {
            get { return _Video_EncodeSpeed_SelectedIndex; }
            set
            {
                if (_Video_EncodeSpeed_SelectedIndex == value)
                {
                    return;
                }

                _Video_EncodeSpeed_SelectedIndex = value;
                OnPropertyChanged("Video_EncodeSpeed_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_EncodeSpeed_SelectedItem { get; set; }
        public string Video_EncodeSpeed_SelectedItem
        {
            get { return _Video_EncodeSpeed_SelectedItem; }
            set
            {
                var previousItem = _Video_EncodeSpeed_SelectedItem;

                if (!string.IsNullOrEmpty(Video_EncodeSpeed_SelectedItem) &&
                    Video_EncodeSpeed_SelectedItem != "None")
                {
                    MainWindow.Video_EncodeSpeed_PreviousItem = previousItem;
                }


                if (_Video_EncodeSpeed_SelectedItem == value)
                {
                    return;
                }

                _Video_EncodeSpeed_SelectedItem = value;
                OnPropertyChanged("Video_EncodeSpeed_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_EncodeSpeed_IsEnabled = true;
        public bool Video_EncodeSpeed_IsEnabled
        {
            get { return _Video_EncodeSpeed_IsEnabled; }
            set
            {
                if (_Video_EncodeSpeed_IsEnabled == value)
                {
                    return;
                }

                _Video_EncodeSpeed_IsEnabled = value;
                OnPropertyChanged("Video_EncodeSpeed_IsEnabled");
            }
        }


        // --------------------------------------------------
        // HW Accel
        // --------------------------------------------------
        // Items Source
        private List<string> _Format_HWAccel_Items = new List<string>()
        {
            "off",
            "dxva2",
            "cuvid",
            "nvenc",
            "cuvid+nvenc"
        };
        public List<string> Format_HWAccel_Items
        {
            get { return _Format_HWAccel_Items; }
            set
            {
                _Format_HWAccel_Items = value;
                OnPropertyChanged("Format_HWAccel_Items");
            }
        }

        // Selected Index
        private int _Format_HWAccel_SelectedIndex { get; set; }
        public int Format_HWAccel_SelectedIndex
        {
            get { return _Format_HWAccel_SelectedIndex; }
            set
            {
                if (_Format_HWAccel_SelectedIndex == value)
                {
                    return;
                }

                _Format_HWAccel_SelectedIndex = value;
                OnPropertyChanged("Format_HWAccel_SelectedIndex");
            }
        }

        // Selected Item
        private string _Format_HWAccel_SelectedItem { get; set; }
        public string Format_HWAccel_SelectedItem
        {
            get { return _Format_HWAccel_SelectedItem; }
            set
            {
                if (_Format_HWAccel_SelectedItem == value)
                {
                    return;
                }

                _Format_HWAccel_SelectedItem = value;
                OnPropertyChanged("Format_HWAccel_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Format_HWAccel_IsEnabled = true;
        public bool Format_HWAccel_IsEnabled
        {
            get { return _Format_HWAccel_IsEnabled; }
            set
            {
                if (_Format_HWAccel_IsEnabled == value)
                {
                    return;
                }

                _Format_HWAccel_IsEnabled = value;
                OnPropertyChanged("Format_HWAccel_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut
        // --------------------------------------------------
        // Items Source
        private List<string> _Format_Cut_Items = new List<string>()
        {
            "No",
            "Yes"
        };
        public List<string> Format_Cut_Items
        {
            get { return _Format_Cut_Items; }
            set
            {
                _Format_Cut_Items = value;
                OnPropertyChanged("Format_Cut_Items");
            }
        }

        // Selected Index
        private int _Format_Cut_SelectedIndex { get; set; }
        public int Format_Cut_SelectedIndex
        {
            get { return _Format_Cut_SelectedIndex; }
            set
            {
                if (_Format_Cut_SelectedIndex == value)
                {
                    return;
                }

                _Format_Cut_SelectedIndex = value;
                OnPropertyChanged("Format_Cut_SelectedIndex");
            }
        }

        // Selected Item
        private string _Format_Cut_SelectedItem { get; set; }
        public string Format_Cut_SelectedItem
        {
            get { return _Format_Cut_SelectedItem; }
            set
            {
                if (_Format_Cut_SelectedItem == value)
                {
                    return;
                }

                _Format_Cut_SelectedItem = value;
                OnPropertyChanged("Format_Cut_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Format_Cut_IsEnabled = true;
        public bool Format_Cut_IsEnabled
        {
            get { return _Format_Cut_IsEnabled; }
            set
            {
                if (_Format_Cut_IsEnabled == value)
                {
                    return;
                }

                _Format_Cut_IsEnabled = value;
                OnPropertyChanged("Format_Cut_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut Start
        // --------------------------------------------------
        // Text
        private string _Format_CutStart_Text = "00:00:00.000";
        public string Format_CutStart_Text
        {
            get { return _Format_CutStart_Text; }
            set
            {
                if (_Format_CutStart_Text == value)
                {
                    return;
                }

                _Format_CutStart_Text = value;
                OnPropertyChanged("Format_CutStart_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutStart_IsEnabled = true;
        public bool Format_CutStart_IsEnabled
        {
            get { return _Format_CutStart_IsEnabled; }
            set
            {
                if (_Format_CutStart_IsEnabled == value)
                {
                    return;
                }

                _Format_CutStart_IsEnabled = value;
                OnPropertyChanged("Format_CutStart_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut Start - Hours
        // --------------------------------------------------
        // Text
        private string _Format_CutStart_Hours_Text;
        public string Format_CutStart_Hours_Text
        {
            get { return _Format_CutStart_Hours_Text; }
            set
            {
                if (_Format_CutStart_Hours_Text == value)
                {
                    return;
                }

                _Format_CutStart_Hours_Text = value;
                OnPropertyChanged("Format_CutStart_Hours_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutStart_Hours_IsEnabled = true;
        public bool Format_CutStart_Hours_IsEnabled
        {
            get { return _Format_CutStart_Hours_IsEnabled; }
            set
            {
                if (_Format_CutStart_Hours_IsEnabled == value)
                {
                    return;
                }

                _Format_CutStart_Hours_IsEnabled = value;
                OnPropertyChanged("Format_CutStart_Hours_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut Start - Minutes
        // --------------------------------------------------
        // Text
        private string _Format_CutStart_Minutes_Text;
        public string Format_CutStart_Minutes_Text
        {
            get { return _Format_CutStart_Minutes_Text; }
            set
            {
                if (_Format_CutStart_Minutes_Text == value)
                {
                    return;
                }

                _Format_CutStart_Minutes_Text = value;
                OnPropertyChanged("Format_CutStart_Minutes_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutStart_Minutes_IsEnabled = true;
        public bool Format_CutStart_Minutes_IsEnabled
        {
            get { return _Format_CutStart_Minutes_IsEnabled; }
            set
            {
                if (_Format_CutStart_Minutes_IsEnabled == value)
                {
                    return;
                }

                _Format_CutStart_Minutes_IsEnabled = value;
                OnPropertyChanged("Format_CutStart_Minutes_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut Start - Seconds
        // --------------------------------------------------
        // Text
        private string _Format_CutStart_Seconds_Text;
        public string Format_CutStart_Seconds_Text
        {
            get { return _Format_CutStart_Seconds_Text; }
            set
            {
                if (_Format_CutStart_Seconds_Text == value)
                {
                    return;
                }

                _Format_CutStart_Seconds_Text = value;
                OnPropertyChanged("Format_CutStart_Seconds_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutStart_Seconds_IsEnabled = true;
        public bool Format_CutStart_Seconds_IsEnabled
        {
            get { return _Format_CutStart_Seconds_IsEnabled; }
            set
            {
                if (_Format_CutStart_Seconds_IsEnabled == value)
                {
                    return;
                }

                _Format_CutStart_Seconds_IsEnabled = value;
                OnPropertyChanged("Format_CutStart_Seconds_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut Start - Milliseconds
        // --------------------------------------------------
        // Text
        private string _Format_CutStart_Milliseconds_Text = "000";
        public string Format_CutStart_Milliseconds_Text
        {
            get { return _Format_CutStart_Milliseconds_Text; }
            set
            {
                if (_Format_CutStart_Milliseconds_Text == value)
                {
                    return;
                }

                _Format_CutStart_Milliseconds_Text = value;
                OnPropertyChanged("Format_CutStart_Milliseconds_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutStart_Milliseconds_IsEnabled = true;
        public bool Format_CutStart_Milliseconds_IsEnabled
        {
            get { return _Format_CutStart_Milliseconds_IsEnabled; }
            set
            {
                if (_Format_CutStart_Milliseconds_IsEnabled == value)
                {
                    return;
                }

                _Format_CutStart_Milliseconds_IsEnabled = value;
                OnPropertyChanged("Format_CutStart_Milliseconds_IsEnabled");
            }
        }



        // --------------------------------------------------
        // Cut End
        // --------------------------------------------------
        // Text
        private string _Format_CutEnd_Text = "00:00:00.000";
        public string Format_CutEnd_Text
        {
            get { return _Format_CutEnd_Text; }
            set
            {
                if (_Format_CutEnd_Text == value)
                {
                    return;
                }

                _Format_CutEnd_Text = value;
                OnPropertyChanged("Format_CutEnd_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutEnd_IsEnabled = true;
        public bool Format_CutEnd_IsEnabled
        {
            get { return _Format_CutEnd_IsEnabled; }
            set
            {
                if (_Format_CutEnd_IsEnabled == value)
                {
                    return;
                }

                _Format_CutEnd_IsEnabled = value;
                OnPropertyChanged("Format_CutEnd_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut End - Hours
        // --------------------------------------------------
        // Text
        private string _Format_CutEnd_Hours_Text;
        public string Format_CutEnd_Hours_Text
        {
            get { return _Format_CutEnd_Hours_Text; }
            set
            {
                if (_Format_CutEnd_Hours_Text == value)
                {
                    return;
                }

                _Format_CutEnd_Hours_Text = value;
                OnPropertyChanged("Format_CutEnd_Hours_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutEnd_Hours_IsEnabled = true;
        public bool Format_CutEnd_Hours_IsEnabled
        {
            get { return _Format_CutEnd_Hours_IsEnabled; }
            set
            {
                if (_Format_CutEnd_Hours_IsEnabled == value)
                {
                    return;
                }

                _Format_CutEnd_Hours_IsEnabled = value;
                OnPropertyChanged("Format_CutEnd_Hours_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut End - Minutes
        // --------------------------------------------------
        // Text
        private string _Format_CutEnd_Minutes_Text;
        public string Format_CutEnd_Minutes_Text
        {
            get { return _Format_CutEnd_Minutes_Text; }
            set
            {
                if (_Format_CutEnd_Minutes_Text == value)
                {
                    return;
                }

                _Format_CutEnd_Minutes_Text = value;
                OnPropertyChanged("Format_CutEnd_Minutes_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutEnd_Minutes_IsEnabled = true;
        public bool Format_CutEnd_Minutes_IsEnabled
        {
            get { return _Format_CutEnd_Minutes_IsEnabled; }
            set
            {
                if (_Format_CutEnd_Minutes_IsEnabled == value)
                {
                    return;
                }

                _Format_CutEnd_Minutes_IsEnabled = value;
                OnPropertyChanged("Format_CutEnd_Minutes_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut End - Seconds
        // --------------------------------------------------
        // Text
        private string _Format_CutEnd_Seconds_Text;
        public string Format_CutEnd_Seconds_Text
        {
            get { return _Format_CutEnd_Seconds_Text; }
            set
            {
                if (_Format_CutEnd_Seconds_Text == value)
                {
                    return;
                }

                _Format_CutEnd_Seconds_Text = value;
                OnPropertyChanged("Format_CutEnd_Seconds_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutEnd_Seconds_IsEnabled = true;
        public bool Format_CutEnd_Seconds_IsEnabled
        {
            get { return _Format_CutEnd_Seconds_IsEnabled; }
            set
            {
                if (_Format_CutEnd_Seconds_IsEnabled == value)
                {
                    return;
                }

                _Format_CutEnd_Seconds_IsEnabled = value;
                OnPropertyChanged("Format_CutEnd_Seconds_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Cut End - Milliseconds
        // --------------------------------------------------
        // Text
        private string _Format_CutEnd_Milliseconds_Text;
        public string Format_CutEnd_Milliseconds_Text
        {
            get { return _Format_CutEnd_Milliseconds_Text; }
            set
            {
                if (_Format_CutEnd_Milliseconds_Text == value)
                {
                    return;
                }

                _Format_CutEnd_Milliseconds_Text = value;
                OnPropertyChanged("Format_CutEnd_Milliseconds_Text");
            }
        }
        // Controls Enable
        private bool _Format_CutEnd_Milliseconds_IsEnabled = true;
        public bool Format_CutEnd_Milliseconds_IsEnabled
        {
            get { return _Format_CutEnd_Milliseconds_IsEnabled; }
            set
            {
                if (_Format_CutEnd_Milliseconds_IsEnabled == value)
                {
                    return;
                }

                _Format_CutEnd_Milliseconds_IsEnabled = value;
                OnPropertyChanged("Format_CutEnd_Milliseconds_IsEnabled");
            }
        }



        // --------------------------------------------------
        // Frame Start
        // --------------------------------------------------
        // Text
        private string _Format_FrameStart_Text;
        public string Format_FrameStart_Text
        {
            get { return _Format_FrameStart_Text; }
            set
            {
                if (_Format_FrameStart_Text == value)
                {
                    return;
                }

                _Format_FrameStart_Text = value;
                OnPropertyChanged("Format_FrameStart_Text");
            }
        }
        // Controls Enable
        private bool _Format_FrameStart_IsEnabled = true;
        public bool Format_FrameStart_IsEnabled
        {
            get { return _Format_FrameStart_IsEnabled; }
            set
            {
                if (_Format_FrameStart_IsEnabled == value)
                {
                    return;
                }

                _Format_FrameStart_IsEnabled = value;
                OnPropertyChanged("Format_FrameStart_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Frame End
        // --------------------------------------------------
        // Text
        private string _Format_FrameEnd_Text;
        public string Format_FrameEnd_Text
        {
            get { return _Format_FrameEnd_Text; }
            set
            {
                if (_Format_FrameEnd_Text == value)
                {
                    return;
                }

                _Format_FrameEnd_Text = value;
                OnPropertyChanged("Format_FrameEnd_Text");
            }
        }
        // Controls Enable
        private bool _Format_FrameEnd_IsEnabled = true;
        public bool Format_FrameEnd_IsEnabled
        {
            get { return _Format_FrameEnd_IsEnabled; }
            set
            {
                if (_Format_FrameEnd_IsEnabled == value)
                {
                    return;
                }

                _Format_FrameEnd_IsEnabled = value;
                OnPropertyChanged("Format_FrameEnd_IsEnabled");
            }
        }



        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Video
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------
        // Video Codec
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_Codec_Items = new List<string>();
        public List<string> Video_Codec_Items
        {
            get { return _Video_Codec_Items; }
            set
            {
                _Video_Codec_Items = value;
                OnPropertyChanged("Video_Codec_Items");
            }
        }

        // Codec and Parameters
        public class VideoCodec
        {
            public string Codec { get; set; }
            public string Parameters { get; set; }
            public string Parameters_Auto { get; set; }
            public string Parameters_CRF { get; set; }
            public string Parameters_1Pass { get; set; }
            public string Parameters_2Pass { get; set; }
            public string Parameters_None { get; set; }
        }

        // Codec Command
        public string Video_Codec;

        // Selected Index
        private int _Video_Codec_SelectedIndex { get; set; }
        public int Video_Codec_SelectedIndex
        {
            get { return _Video_Codec_SelectedIndex; }
            set
            {
                if (_Video_Codec_SelectedIndex == value)
                {
                    return;
                }

                _Video_Codec_SelectedIndex = value;
                OnPropertyChanged("Video_Codec_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Codec_SelectedItem { get; set; }
        public string Video_Codec_SelectedItem
        {
            get { return _Video_Codec_SelectedItem; }
            set
            {
                if (_Video_Codec_SelectedItem == value)
                {
                    return;
                }

                _Video_Codec_SelectedItem = value;
                OnPropertyChanged("Video_Codec_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Codec_IsEnabled = true;
        public bool Video_Codec_IsEnabled
        {
            get { return _Video_Codec_IsEnabled; }
            set
            {
                if (_Video_Codec_IsEnabled == value)
                {
                    return;
                }

                _Video_Codec_IsEnabled = value;
                OnPropertyChanged("Video_Codec_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Pass
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_Pass_Items = new List<string>()
        {
            "CRF",
            "1 Pass",
            "2 Pass"
        };
        public List<string> Video_Pass_Items
        {
            get { return _Video_Pass_Items; }
            set
            {
                _Video_Pass_Items = value;
                OnPropertyChanged("Video_Pass_Items");
            }
        }

        // Selected Index
        private int _Video_Pass_SelectedIndex { get; set; }
        public int Video_Pass_SelectedIndex
        {
            get { return _Video_Pass_SelectedIndex; }
            set
            {
                if (_Video_Pass_SelectedIndex == value)
                {
                    return;
                }

                _Video_Pass_SelectedIndex = value;
                OnPropertyChanged("Video_Pass_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Pass_SelectedItem { get; set; }
        public string Video_Pass_SelectedItem
        {
            get { return _Video_Pass_SelectedItem; }
            set
            {
                if (_Video_Pass_SelectedItem == value)
                {
                    return;
                }

                _Video_Pass_SelectedItem = value;
                OnPropertyChanged("Video_Pass_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Pass_IsEnabled = true;
        public bool Video_Pass_IsEnabled
        {
            get { return _Video_Pass_IsEnabled; }
            set
            {
                if (_Video_Pass_IsEnabled == value)
                {
                    return;
                }

                _Video_Pass_IsEnabled = value;
                OnPropertyChanged("Video_Pass_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Video Quality
        // --------------------------------------------------
        public class VideoQuality
        {
            public string Name { get; set; }
            public string NA { get; set; }
            public string Lossless { get; set; }
            public string CRF { get; set; }
            public string Video_CRF_Bitrate { get; set; }
            public string CBR_BitMode { get; set; }
            public string CBR { get; set; }
            public string VBR_BitMode { get; set; }
            public string VBR { get; set; }
            public string Minrate { get; set; }
            public string Maxrate { get; set; }
            public string Bufsize { get; set; }
            //public string Custom { get; set; }
        }
        private List<VideoQuality> _Video_Quality_Items = new List<VideoQuality>();
        public List<VideoQuality> Video_Quality_Items
        {
            get { return _Video_Quality_Items; }
            set
            {
                _Video_Quality_Items = value;
                OnPropertyChanged("Video_Quality_Items");
            }
        }

        // Command
        //public string VideoBitrateMode_Command;

        // Selected Index
        private int _Video_Quality_SelectedIndex { get; set; }
        public int Video_Quality_SelectedIndex
        {
            get { return _Video_Quality_SelectedIndex; }
            set
            {
                if (_Video_Quality_SelectedIndex == value)
                {
                    return;
                }

                _Video_Quality_SelectedIndex = value;
                OnPropertyChanged("Video_Quality_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Quality_SelectedItem { get; set; }
        public string Video_Quality_SelectedItem
        {
            get { return _Video_Quality_SelectedItem; }
            set
            {
                var previousItem = _Video_Quality_SelectedItem;
                _Video_Quality_SelectedItem = value;
                OnPropertyChanged("Video_Quality_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_Quality_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_Quality_SelectedItem = value;
                //OnPropertyChanged("Video_Quality_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Quality_IsEnabled = true;
        public bool Video_Quality_IsEnabled
        {
            get { return _Video_Quality_IsEnabled; }
            set
            {
                if (_Video_Quality_IsEnabled == value)
                {
                    return;
                }

                _Video_Quality_IsEnabled = value;
                OnPropertyChanged("Video_Quality_IsEnabled");
            }
        }


        // -------------------------
        // Video VBR - Toggle
        // -------------------------
        // Checked
        private bool _Video_VBR_IsChecked;
        public bool Video_VBR_IsChecked
        {
            get { return _Video_VBR_IsChecked; }
            set
            {
                if (_Video_VBR_IsChecked != value)
                {
                    _Video_VBR_IsChecked = value;
                    OnPropertyChanged("Video_VBR_IsChecked");
                }
            }
        }
        //private bool _Video_VBR_IsChecked;
        //public bool Video_VBR_IsChecked
        //{
        //    get { return _Video_VBR_IsChecked; }
        //    set
        //    {
        //        if (_Video_VBR_IsChecked == value) return;

        //        _Video_VBR_IsChecked = value;
        //    }
        //}
        // Enabled
        private bool _Video_VBR_IsEnabled = true;
        public bool Video_VBR_IsEnabled
        {
            get { return _Video_VBR_IsEnabled; }
            set
            {
                if (_Video_VBR_IsEnabled == value)
                {
                    return;
                }

                _Video_VBR_IsEnabled = value;
                OnPropertyChanged("Video_VBR_IsEnabled");
            }
        }


        // -------------------------
        // CRF
        // -------------------------
        // Text
        private string _Video_CRF_Text;
        public string Video_CRF_Text
        {
            get { return _Video_CRF_Text; }
            set
            {
                if (_Video_CRF_Text == value)
                {
                    return;
                }

                _Video_CRF_Text = value;
                OnPropertyChanged("Video_CRF_Text");
            }
        }
        // Enabled
        private bool _Video_CRF_IsEnabled = true;
        public bool Video_CRF_IsEnabled
        {
            get { return _Video_CRF_IsEnabled; }
            set
            {
                if (_Video_CRF_IsEnabled == value)
                {
                    return;
                }

                _Video_CRF_IsEnabled = value;
                OnPropertyChanged("Video_CRF_IsEnabled");
            }
        }


        // -------------------------
        // Video Bitrate
        // -------------------------
        // Text
        private string _Video_Bitrate_Text;
        public string Video_Bitrate_Text
        {
            get { return _Video_Bitrate_Text; }
            set
            {
                if (_Video_Bitrate_Text == value)
                {
                    return;
                }

                _Video_Bitrate_Text = value;
                OnPropertyChanged("Video_Bitrate_Text");
            }
        }
        // Enabled
        private bool _Video_Bitrate_IsEnabled = true;
        public bool Video_Bitrate_IsEnabled
        {
            get { return _Video_Bitrate_IsEnabled; }
            set
            {
                if (_Video_Bitrate_IsEnabled == value)
                {
                    return;
                }

                _Video_Bitrate_IsEnabled = value;
                OnPropertyChanged("Video_Bitrate_IsEnabled");
            }
        }


        // -------------------------
        // Video Minrate
        // -------------------------
        // Text
        private string _Video_Minrate_Text;
        public string Video_Minrate_Text
        {
            get { return _Video_Minrate_Text; }
            set
            {
                if (_Video_Minrate_Text == value)
                {
                    return;
                }

                _Video_Minrate_Text = value;
                OnPropertyChanged("Video_Minrate_Text");
            }
        }
        // Enabled
        private bool _Video_Minrate_IsEnabled = true;
        public bool Video_Minrate_IsEnabled
        {
            get { return _Video_Minrate_IsEnabled; }
            set
            {
                if (_Video_Minrate_IsEnabled == value)
                {
                    return;
                }

                _Video_Minrate_IsEnabled = value;
                OnPropertyChanged("Video_Minrate_IsEnabled");
            }
        }

        // -------------------------
        // Video Maxrate
        // -------------------------
        // Text
        private string _Video_Maxrate_Text;
        public string Video_Maxrate_Text
        {
            get { return _Video_Maxrate_Text; }
            set
            {
                if (_Video_Maxrate_Text == value)
                {
                    return;
                }

                _Video_Maxrate_Text = value;
                OnPropertyChanged("Video_Maxrate_Text");
            }
        }
        // Enabled
        private bool _Video_Maxrate_IsEnabled = true;
        public bool Video_Maxrate_IsEnabled
        {
            get { return _Video_Maxrate_IsEnabled; }
            set
            {
                if (_Video_Maxrate_IsEnabled == value)
                {
                    return;
                }

                _Video_Maxrate_IsEnabled = value;
                OnPropertyChanged("Video_Maxrate_IsEnabled");
            }
        }


        // -------------------------
        // Video Bufsize
        // -------------------------
        // Text
        private string _Video_Bufsize_Text;
        public string Video_Bufsize_Text
        {
            get { return _Video_Bufsize_Text; }
            set
            {
                if (_Video_Bufsize_Text == value)
                {
                    return;
                }

                _Video_Bufsize_Text = value;
                OnPropertyChanged("Video_Bufsize_Text");
            }
        }
        // Enabled
        private bool _Video_Bufsize_IsEnabled = true;
        public bool Video_Bufsize_IsEnabled
        {
            get { return _Video_Bufsize_IsEnabled; }
            set
            {
                if (_Video_Bufsize_IsEnabled == value)
                {
                    return;
                }

                _Video_Bufsize_IsEnabled = value;
                OnPropertyChanged("Video_Bufsize_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Pixel Format
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_PixelFormat_Items = new List<string>();
        public List<string> Video_PixelFormat_Items
        {
            get { return _Video_PixelFormat_Items; }
            set
            {
                _Video_PixelFormat_Items = value;
                OnPropertyChanged("Video_PixelFormat_Items");
            }
        }

        // Selected Index
        private int _Video_PixelFormat_SelectedIndex { get; set; }
        public int Video_PixelFormat_SelectedIndex
        {
            get { return _Video_PixelFormat_SelectedIndex; }
            set
            {
                if (_Video_PixelFormat_SelectedIndex == value)
                {
                    return;
                }

                _Video_PixelFormat_SelectedIndex = value;
                OnPropertyChanged("Video_PixelFormat_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_PixelFormat_SelectedItem { get; set; }
        public string Video_PixelFormat_SelectedItem
        {
            get { return _Video_PixelFormat_SelectedItem; }
            set
            {
                var previousItem = _Video_PixelFormat_SelectedItem;
                _Video_PixelFormat_SelectedItem = value;
                OnPropertyChanged("Video_PixelFormat_SelectedItem");

                if (previousItem != value)
                {
                    //VideoControls.AutoCopyVideoCodec(this); // Crash Problem
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }
                //if (_Video_PixelFormat_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_PixelFormat_SelectedItem = value;
                //OnPropertyChanged("Video_PixelFormat_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_PixelFormat_IsEnabled = true;
        public bool Video_PixelFormat_IsEnabled
        {
            get { return _Video_PixelFormat_IsEnabled; }
            set
            {
                if (_Video_PixelFormat_IsEnabled == value)
                {
                    return;
                }

                _Video_PixelFormat_IsEnabled = value;
                OnPropertyChanged("Video_PixelFormat_IsEnabled");
            }
        }


        // --------------------------------------------------
        // FPS
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_FPS_Items = new List<string>()
        {
            "auto",
            "ntsc",
            "pal",
            "film",
            "23.976",
            "24",
            "25",
            "29.97",
            "30",
            "48",
            "50",
            "59.94",
            "60",
            "Custom"
        };
        public List<string> Video_FPS_Items
        {
            get { return _Video_FPS_Items; }
            set
            {
                _Video_FPS_Items = value;
                OnPropertyChanged("Video_FPS_Items");
            }
        }

        // Selected Index
        private int _Video_FPS_SelectedIndex { get; set; }
        public int Video_FPS_SelectedIndex
        {
            get { return _Video_FPS_SelectedIndex; }
            set
            {
                if (_Video_FPS_SelectedIndex == value)
                {
                    return;
                }

                _Video_FPS_SelectedIndex = value;
                OnPropertyChanged("Video_FPS_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_FPS_SelectedItem { get; set; }
        public string Video_FPS_SelectedItem
        {
            get { return _Video_FPS_SelectedItem; }
            set
            {
                var previousItem = _Video_FPS_SelectedItem;
                _Video_FPS_SelectedItem = value;
                OnPropertyChanged("Video_FPS_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_FPS_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_FPS_SelectedItem = value;
                //OnPropertyChanged("Video_FPS_SelectedItem");
            }
        }

        // Text
        private string _Video_FPS_Text;
        public string Video_FPS_Text
        {
            get { return _Video_FPS_Text; }
            set
            {
                if (_Video_FPS_Text == value)
                {
                    return;
                }

                _Video_FPS_Text = value;
                OnPropertyChanged("Video_FPS_Text");
            }
        }

        // Controls Is Editable
        private bool _Video_FPS_IsEditable = false;
        public bool Video_FPS_IsEditable
        {
            get { return _Video_FPS_IsEditable; }
            set
            {
                if (_Video_FPS_IsEditable == value)
                {
                    return;
                }

                _Video_FPS_IsEditable = value;
                OnPropertyChanged("Video_FPS_IsEditable");
            }
        }

         // Controls Enable
        private bool _Video_FPS_IsEnabled = true;
        public bool Video_FPS_IsEnabled
        {
            get { return _Video_FPS_IsEnabled; }
            set
            {
                if (_Video_FPS_IsEnabled == value)
                {
                    return;
                }

                _Video_FPS_IsEnabled = value;
                OnPropertyChanged("Video_FPS_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Speed
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_Speed_Items = new List<string>()
        {
            "auto",
            "10%",
            "25%",
            "50%",
            "75%",
            //"100%", default
            "150%",
            "200%",
            "250%",
            "300%",
            "500%",
            "Custom"
        };
        public List<string> Video_Speed_Items
        {
            get { return _Video_Speed_Items; }
            set
            {
                _Video_Speed_Items = value;
                OnPropertyChanged("Video_Speed_Items");
            }
        }

        // Selected Index
        private int _Video_Speed_SelectedIndex { get; set; }
        public int Video_Speed_SelectedIndex
        {
            get { return _Video_Speed_SelectedIndex; }
            set
            {
                if (_Video_Speed_SelectedIndex == value)
                {
                    return;
                }

                _Video_Speed_SelectedIndex = value;
                OnPropertyChanged("Video_Speed_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Speed_SelectedItem { get; set; }
        public string Video_Speed_SelectedItem
        {
            get { return _Video_Speed_SelectedItem; }
            set
            {
                var previousItem = _Video_Speed_SelectedItem;
                _Video_Speed_SelectedItem = value;
                OnPropertyChanged("Video_Speed_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_Speed_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_Speed_SelectedItem = value;
                //OnPropertyChanged("Video_Speed_SelectedItem");
            }
        }

        // Text
        private string _Video_Speed_Text;
        public string Video_Speed_Text
        {
            get { return _Video_Speed_Text; }
            set
            {
                if (_Video_Speed_Text == value)
                {
                    return;
                }

                _Video_Speed_Text = value;
                OnPropertyChanged("Video_Speed_Text");
            }
        }

        // Controls Is Editable
        private bool _Video_Speed_IsEditable = false;
        public bool Video_Speed_IsEditable
        {
            get { return _Video_Speed_IsEditable; }
            set
            {
                if (_Video_Speed_IsEditable == value)
                {
                    return;
                }

                _Video_Speed_IsEditable = value;
                OnPropertyChanged("Video_Speed_IsEditable");
            }
        }

        // Controls Enable
        private bool _Video_Speed_IsEnabled = true;
        public bool Video_Speed_IsEnabled
        {
            get { return _Video_Speed_IsEnabled; }
            set
            {
                if (_Video_Speed_IsEnabled == value)
                {
                    return;
                }

                _Video_Speed_IsEnabled = value;
                OnPropertyChanged("Video_Speed_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Optimize
        // --------------------------------------------------
        public class VideoOptimize
        {
            public string Name { get; set; }
            public string Command { get; set; }
            public string Tune { get; set; }
            public string Profile { get; set; }
            public string Level { get; set; }
        }
        private List<VideoOptimize> _Video_Optimize_Items = new List<VideoOptimize>();
        // Items Source
        //private List<string> _Optimize_Items = new List<string>();
        public List<VideoOptimize> Video_Optimize_Items
        {
            get { return _Video_Optimize_Items; }
            set
            {
                _Video_Optimize_Items = value;
                OnPropertyChanged("Video_Optimize_Items");
            }
        }

        // Selected Index
        private int _Video_Optimize_SelectedIndex { get; set; }
        public int Video_Optimize_SelectedIndex
        {
            get { return _Video_Optimize_SelectedIndex; }
            set
            {
                if (_Video_Optimize_SelectedIndex == value)
                {
                    return;
                }

                _Video_Optimize_SelectedIndex = value;
                OnPropertyChanged("Video_Optimize_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Optimize_SelectedItem { get; set; }
        public string Video_Optimize_SelectedItem
        {
            get { return _Video_Optimize_SelectedItem; }
            set
            {
                var previousItem = _Video_Optimize_SelectedItem;
                _Video_Optimize_SelectedItem = value;
                OnPropertyChanged("Video_Optimize_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_Optimize_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_Optimize_SelectedItem = value;
                //OnPropertyChanged("Video_Optimize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Optimize_IsEnabled = true;
        public bool Video_Optimize_IsEnabled
        {
            get { return _Video_Optimize_IsEnabled; }
            set
            {
                if (_Video_Optimize_IsEnabled == value)
                {
                    return;
                }

                _Video_Optimize_IsEnabled = value;
                OnPropertyChanged("Video_Optimize_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Optimize Tune
        // --------------------------------------------------
        // Items Source
        private List<string> _Optimize_Tune_Items = new List<string>();
        public List<string> Optimize_Tune_Items
        {
            get { return _Optimize_Tune_Items; }
            set
            {
                _Optimize_Tune_Items = value;
                OnPropertyChanged("Optimize_Tune_Items");
            }
        }

        // Selected Index
        private int _Optimize_Tune_SelectedIndex { get; set; }
        public int Optimize_Tune_SelectedIndex
        {
            get { return _Optimize_Tune_SelectedIndex; }
            set
            {
                if (_Optimize_Tune_SelectedIndex == value)
                {
                    return;
                }

                _Optimize_Tune_SelectedIndex = value;
                OnPropertyChanged("Optimize_Tune_SelectedIndex");
            }
        }

        // Selected Item
        public string _Video_Optimize_Tune_SelectedItem { get; set; }
        public string Video_Optimize_Tune_SelectedItem
        {
            get { return _Video_Optimize_Tune_SelectedItem; }
            set
            {
                if (_Video_Optimize_Tune_SelectedItem == value)
                {
                    return;
                }

                _Video_Optimize_Tune_SelectedItem = value;
                OnPropertyChanged("Video_Optimize_Tune_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Optimize_Tune_IsEnabled = true;
        public bool Optimize_Tune_IsEnabled
        {
            get { return _Optimize_Tune_IsEnabled; }
            set
            {
                if (_Optimize_Tune_IsEnabled == value)
                {
                    return;
                }

                _Optimize_Tune_IsEnabled = value;
                OnPropertyChanged("Optimize_Tune_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Optimize Profile
        // --------------------------------------------------
        // Items Source
        private List<string> _Optimize_Profile_Items = new List<string>();
        public List<string> Optimize_Profile_Items
        {
            get { return _Optimize_Profile_Items; }
            set
            {
                _Optimize_Profile_Items = value;
                OnPropertyChanged("Optimize_Profile_Items");
            }
        }

        // Selected Index
        private int _Optimize_Profile_SelectedIndex { get; set; }
        public int Optimize_Profile_SelectedIndex
        {
            get { return _Optimize_Profile_SelectedIndex; }
            set
            {
                if (_Optimize_Profile_SelectedIndex == value)
                {
                    return;
                }

                _Optimize_Profile_SelectedIndex = value;
                OnPropertyChanged("Optimize_Profile_SelectedIndex");
            }
        }

        // Selected Item
        public string _Video_Optimize_Profile_SelectedItem { get; set; }
        public string Video_Optimize_Profile_SelectedItem
        {
            get { return _Video_Optimize_Profile_SelectedItem; }
            set
            {
                if (_Video_Optimize_Profile_SelectedItem == value)
                {
                    return;
                }

                _Video_Optimize_Profile_SelectedItem = value;
                OnPropertyChanged("Video_Optimize_Profile_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Optimize_Profile_IsEnabled = true;
        public bool Optimize_Profile_IsEnabled
        {
            get { return _Optimize_Profile_IsEnabled; }
            set
            {
                if (_Optimize_Profile_IsEnabled == value)
                {
                    return;
                }

                _Optimize_Profile_IsEnabled = value;
                OnPropertyChanged("Optimize_Profile_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Optimize Level
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_Optimize_Level_Items = new List<string>();
        public List<string> Video_Optimize_Level_Items
        {
            get { return _Video_Optimize_Level_Items; }
            set
            {
                _Video_Optimize_Level_Items = value;
                OnPropertyChanged("Video_Optimize_Level_Items");
            }
        }

        // Selected Index
        private int _Video_Optimize_Level_SelectedIndex { get; set; }
        public int Video_Optimize_Level_SelectedIndex
        {
            get { return _Video_Optimize_Level_SelectedIndex; }
            set
            {
                if (_Video_Optimize_Level_SelectedIndex == value)
                {
                    return;
                }

                _Video_Optimize_Level_SelectedIndex = value;
                OnPropertyChanged("Video_Optimize_Level_SelectedIndex");
            }
        }

        // Selected Item
        public string _Video_Optimize_Level_SelectedItem { get; set; }
        public string Video_Optimize_Level_SelectedItem
        {
            get { return _Video_Optimize_Level_SelectedItem; }
            set
            {
                if (_Video_Optimize_Level_SelectedItem == value)
                {
                    return;
                }

                _Video_Optimize_Level_SelectedItem = value;
                OnPropertyChanged("Video_Optimize_Level_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Optimize_Level_IsEnabled = true;
        public bool Video_Optimize_Level_IsEnabled
        {
            get { return _Video_Optimize_Level_IsEnabled; }
            set
            {
                if (_Video_Optimize_Level_IsEnabled == value)
                {
                    return;
                }

                _Video_Optimize_Level_IsEnabled = value;
                OnPropertyChanged("Video_Optimize_Level_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Size
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_Scale_Items = new List<string>()
        {
            "Source",
            "8K",
            "4K",
            "4K UHD",
            "2K",
            "1440p",
            "1200p",
            "1080p",
            "720p",
            "480p",
            "320p",
            "240p",
            "Custom"
        };
        public List<string> Video_Scale_Items
        {
            get { return _Video_Scale_Items; }
            set
            {
                _Video_Scale_Items = value;
                OnPropertyChanged("Video_Scale_Items");
            }
        }

        // Selected Index
        private int _Video_Scale_SelectedIndex { get; set; }
        public int Video_Scale_SelectedIndex
        {
            get { return _Video_Scale_SelectedIndex; }
            set
            {
                if (_Video_Scale_SelectedIndex == value)
                {
                    return;
                }

                _Video_Scale_SelectedIndex = value;
                OnPropertyChanged("Video_Scale_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_Scale_SelectedItem { get; set; }
        public string Video_Scale_SelectedItem
        {
            get { return _Video_Scale_SelectedItem; }
            set
            {
                var previousItem = _Video_Scale_SelectedItem;
                _Video_Scale_SelectedItem = value;
                OnPropertyChanged("Video_Scale_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_Scale_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_Scale_SelectedItem = value;
                //OnPropertyChanged("Video_Scale_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_Scale_IsEnabled = true;
        public bool Video_Scale_IsEnabled
        {
            get { return _Video_Scale_IsEnabled; }
            set
            {
                if (_Video_Scale_IsEnabled == value)
                {
                    return;
                }

                _Video_Scale_IsEnabled = value;
                OnPropertyChanged("Video_Scale_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Width
        // --------------------------------------------------
        // Text
        private string _Video_Width_Text;
        public string Video_Width_Text
        {
            get { return _Video_Width_Text; }
            set
            {
                if (_Video_Width_Text == value)
                {
                    return;
                }

                _Video_Width_Text = value;
                OnPropertyChanged("Video_Width_Text");
            }
        }
        // Enabled
        private bool _Video_Width_IsEnabled = true;
        public bool Video_Width_IsEnabled
        {
            get { return _Video_Width_IsEnabled; }
            set
            {
                if (_Video_Width_IsEnabled == value)
                {
                    return;
                }

                _Video_Width_IsEnabled = value;
                OnPropertyChanged("Video_Width_IsEnabled");
            }
        }
        // --------------------------------------------------
        // Height
        // --------------------------------------------------
        // Text
        private string _Video_Height_Text;
        public string Video_Height_Text
        {
            get { return _Video_Height_Text; }
            set
            {
                if (_Video_Height_Text == value)
                {
                    return;
                }

                _Video_Height_Text = value;
                OnPropertyChanged("Video_Height_Text");
            }
        }
        // Enabled
        private bool _Video_Height_IsEnabled = true;
        public bool Video_Height_IsEnabled
        {
            get { return _Video_Height_IsEnabled; }
            set
            {
                if (_Video_Height_IsEnabled == value)
                {
                    return;
                }

                _Video_Height_IsEnabled = value;
                OnPropertyChanged("Video_Height_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Aspect Ratio
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_AspectRatio_Items = new List<string>()
        {
            "auto",
            "1:1",
            "3:2",
            "4:3",
            "5:4",
            "8:7",
            "14:10",
            "16:9",
            "16:10",
            "19:10",
            "21:9",
            "32:9"
        };
        public List<string> Video_AspectRatio_Items
        {
            get { return _Video_AspectRatio_Items; }
            set
            {
                _Video_AspectRatio_Items = value;
                OnPropertyChanged("Video_AspectRatio_Items");
            }
        }

        // Selected Index
        private int _Video_AspectRatio_SelectedIndex { get; set; }
        public int Video_AspectRatio_SelectedIndex
        {
            get { return _Video_AspectRatio_SelectedIndex; }
            set
            {
                if (_Video_AspectRatio_SelectedIndex == value)
                {
                    return;
                }

                _Video_AspectRatio_SelectedIndex = value;
                OnPropertyChanged("Video_AspectRatio_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_AspectRatio_SelectedItem { get; set; }
        public string Video_AspectRatio_SelectedItem
        {
            get { return _Video_AspectRatio_SelectedItem; }
            set
            {
                var previousItem = _Video_AspectRatio_SelectedItem;
                _Video_AspectRatio_SelectedItem = value;
                OnPropertyChanged("Video_AspectRatio_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_AspectRatio_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_AspectRatio_SelectedItem = value;
                //OnPropertyChanged("Video_AspectRatio_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_AspectRatio_IsEnabled = true;
        public bool Video_AspectRatio_IsEnabled
        {
            get { return _Video_AspectRatio_IsEnabled; }
            set
            {
                if (_Video_AspectRatio_IsEnabled == value)
                {
                    return;
                }

                _Video_AspectRatio_IsEnabled = value;
                OnPropertyChanged("Video_AspectRatio_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Scaling
        // --------------------------------------------------
        // Items Source
        private List<string> _Video_ScalingAlgorithm_Items = new List<string>()
        {
            "default",
            "neighbor",
            "area",
            "fast_bilinear",
            "bilinear",
            "bicubic",
            "experimental",
            "bicublin",
            "gauss",
            "sinc",
            "lanczos",
            "spline"
        };
        public List<string> Video_ScalingAlgorithm_Items
        {
            get { return _Video_ScalingAlgorithm_Items; }
            set
            {
                _Video_ScalingAlgorithm_Items = value;
                OnPropertyChanged("Video_ScalingAlgorithm_Items");
            }
        }

        // Selected Index
        private int _Video_ScalingAlgorithm_SelectedIndex { get; set; }
        public int Video_ScalingAlgorithm_SelectedIndex
        {
            get { return _Video_ScalingAlgorithm_SelectedIndex; }
            set
            {
                if (_Video_ScalingAlgorithm_SelectedIndex == value)
                {
                    return;
                }

                _Video_ScalingAlgorithm_SelectedIndex = value;
                OnPropertyChanged("Video_ScalingAlgorithm_SelectedIndex");
            }
        }

        // Selected Item
        private string _Video_ScalingAlgorithm_SelectedItem { get; set; }
        public string Video_ScalingAlgorithm_SelectedItem
        {
            get { return _Video_ScalingAlgorithm_SelectedItem; }
            set
            {
                var previousItem = _Video_ScalingAlgorithm_SelectedItem;
                _Video_ScalingAlgorithm_SelectedItem = value;
                OnPropertyChanged("Video_ScalingAlgorithm_SelectedItem");

                if (previousItem != value)
                {
                    VideoControls.AutoCopyVideoCodec(this);
                    SubtitleControls.AutoCopySubtitleCodec(this);
                }

                //if (_Video_ScalingAlgorithm_SelectedItem == value)
                //{
                //    return;
                //}

                //_Video_ScalingAlgorithm_SelectedItem = value;
                //OnPropertyChanged("Video_ScalingAlgorithm_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Video_ScalingAlgorithm_IsEnabled = true;
        public bool Video_ScalingAlgorithm_IsEnabled
        {
            get { return _Video_ScalingAlgorithm_IsEnabled; }
            set
            {
                if (_Video_ScalingAlgorithm_IsEnabled == value)
                {
                    return;
                }

                _Video_ScalingAlgorithm_IsEnabled = value;
                OnPropertyChanged("Video_ScalingAlgorithm_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Crop
        // --------------------------------------------------
        // Controls Enable
        private bool _Video_Crop_IsEnabled = true;
        public bool Video_Crop_IsEnabled
        {
            get { return _Video_Crop_IsEnabled; }
            set
            {
                if (_Video_Crop_IsEnabled == value)
                {
                    return;
                }

                _Video_Crop_IsEnabled = value;
                OnPropertyChanged("Video_Crop_IsEnabled");
            }
        }

        // -------------------------
        // Crop Width
        // -------------------------
        // Text
        private string _Video_Crop_Width_Text;
        public string Video_Crop_Width_Text
        {
            get { return _Video_Crop_Width_Text; }
            set
            {
                if (_Video_Crop_Width_Text == value)
                {
                    return;
                }

                _Video_Crop_Width_Text = value;
                OnPropertyChanged("Video_Crop_Width_Text");
            }
        }

        // -------------------------
        // Crop Height
        // -------------------------
        // Text
        private string _Video_Crop_Height_Text;
        public string Video_Crop_Height_Text
        {
            get { return _Video_Crop_Height_Text; }
            set
            {
                if (_Video_Crop_Height_Text == value)
                {
                    return;
                }

                _Video_Crop_Height_Text = value;
                OnPropertyChanged("Video_Crop_Height_Text");
            }
        }

        // -------------------------
        // Crop X
        // -------------------------
        // Text
        private string _Video_Crop_X_Text;
        public string Video_Crop_X_Text
        {
            get { return _Video_Crop_X_Text; }
            set
            {
                if (_Video_Crop_X_Text == value)
                {
                    return;
                }

                _Video_Crop_X_Text = value;
                OnPropertyChanged("Video_Crop_X_Text");
            }
        }

        // -------------------------
        // Crop X
        // -------------------------
        private string _Video_Crop_Y_Text;
        public string Video_Crop_Y_Text
        {
            get { return _Video_Crop_Y_Text; }
            set
            {
                if (_Video_Crop_Y_Text == value)
                {
                    return;
                }

                _Video_Crop_Y_Text = value;
                OnPropertyChanged("Video_Crop_Y_Text");
            }
        }



        // --------------------------------------------------
        // Crop Clear Button
        // --------------------------------------------------
        // Text
        private string _Video_CropClear_Text = "Clear";
        public string Video_CropClear_Text
        {
            get { return _Video_CropClear_Text; }
            set
            {
                if (_Video_CropClear_Text == value)
                {
                    return;
                }

                _Video_CropClear_Text = value;
                OnPropertyChanged("Video_CropClear_Text");
            }
        }




        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Audio
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------
        // Audio Codec
        // --------------------------------------------------
        // Items Source
        private List<string> _Audio_Codec_Items = new List<string>();
        public List<string> Audio_Codec_Items
        {
            get { return _Audio_Codec_Items; }
            set
            {
                _Audio_Codec_Items = value;
                OnPropertyChanged("Audio_Codec_Items");
            }
        }

        // Codec and Parameters
        public class AudioCodec
        {
            public string Codec { get; set; }
            public string Parameters { get; set; }
        }

        // Codec Command
        public string Audio_Codec;

        // Selected Index
        private int _Audio_Codec_SelectedIndex { get; set; }
        public int Audio_Codec_SelectedIndex
        {
            get { return _Audio_Codec_SelectedIndex; }
            set
            {
                if (_Audio_Codec_SelectedIndex == value)
                {
                    return;
                }

                _Audio_Codec_SelectedIndex = value;
                OnPropertyChanged("Audio_Codec_SelectedIndex");
            }
        }

        // Selected Item
        private string _Audio_Codec_SelectedItem { get; set; }
        public string Audio_Codec_SelectedItem
        {
            get { return _Audio_Codec_SelectedItem; }
            set
            {
                if (_Audio_Codec_SelectedItem == value)
                {
                    return;
                }

                _Audio_Codec_SelectedItem = value;
                OnPropertyChanged("Audio_Codec_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_Codec_IsEnabled = true;
        public bool Audio_Codec_IsEnabled
        {
            get { return _Audio_Codec_IsEnabled; }
            set
            {
                if (_Audio_Codec_IsEnabled == value)
                {
                    return;
                }

                _Audio_Codec_IsEnabled = value;
                OnPropertyChanged("Audio_Codec_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Audio Stream
        // --------------------------------------------------
        // Items Source
        private List<string> _Audio_Stream_Items = new List<string>()
        {
            "none",
            "all",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
        };
        public List<string> Audio_Stream_Items
        {
            get { return _Audio_Stream_Items; }
            set
            {
                _Audio_Stream_Items = value;
                OnPropertyChanged("Audio_Stream_Items");
            }
        }

        // Selected Index
        private int _Audio_Stream_SelectedIndex { get; set; }
        public int Audio_Stream_SelectedIndex
        {
            get { return _Audio_Stream_SelectedIndex; }
            set
            {
                if (_Audio_Stream_SelectedIndex == value)
                {
                    return;
                }

                _Audio_Stream_SelectedIndex = value;
                OnPropertyChanged("Audio_Stream_SelectedIndex");
            }
        }

        // Selected Item
        private string _Audio_Stream_SelectedItem { get; set; }
        public string Audio_Stream_SelectedItem
        {
            get { return _Audio_Stream_SelectedItem; }
            set
            {
                if (_Audio_Stream_SelectedItem == value)
                {
                    return;
                }

                _Audio_Stream_SelectedItem = value;
                OnPropertyChanged("Audio_Stream_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_Stream_IsEnabled = true;
        public bool Audio_Stream_IsEnabled
        {
            get { return _Audio_Stream_IsEnabled; }
            set
            {
                if (_Audio_Stream_IsEnabled == value)
                {
                    return;
                }

                _Audio_Stream_IsEnabled = value;
                OnPropertyChanged("Audio_Stream_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Audio Channel
        // --------------------------------------------------
        // Items Source
        private List<string> _Audio_Channel_Items = new List<string>();
        public List<string> Audio_Channel_Items
        {
            get { return _Audio_Channel_Items; }
            set
            {
                _Audio_Channel_Items = value;
                OnPropertyChanged("Audio_Channel_Items");
            }
        }

        // Selected Index
        private int _Audio_Channel_SelectedIndex { get; set; }
        public int Audio_Channel_SelectedIndex
        {
            get { return _Audio_Channel_SelectedIndex; }
            set
            {
                if (_Audio_Channel_SelectedIndex == value)
                {
                    return;
                }

                _Audio_Channel_SelectedIndex = value;
                OnPropertyChanged("Audio_Channel_SelectedIndex");
            }
        }

        // Selected Item
        private string _Audio_Channel_SelectedItem { get; set; }
        public string Audio_Channel_SelectedItem
        {
            get { return _Audio_Channel_SelectedItem; }
            set
            {
                var previousItem = _Audio_Channel_SelectedItem;
                _Audio_Channel_SelectedItem = value;
                OnPropertyChanged("Audio_Channel_SelectedItem");

                if (previousItem != value)
                {
                    AudioControls.AutoCopyAudioCodec(this);
                }

                //if (_Audio_Channel_SelectedItem == value)
                //{
                //    return;
                //}

                //_Audio_Channel_SelectedItem = value;
                //OnPropertyChanged("Audio_Channel_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_Channel_IsEnabled = true;
        public bool Audio_Channel_IsEnabled
        {
            get { return _Audio_Channel_IsEnabled; }
            set
            {
                if (_Audio_Channel_IsEnabled == value)
                {
                    return;
                }

                _Audio_Channel_IsEnabled = value;
                OnPropertyChanged("Audio_Channel_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Audio Quality
        // --------------------------------------------------
        // Items Source
        public class AudioQuality
        {
            public string Name { get; set; }
            public string NA { get; set; }
            //public string Auto { get; set; }
            public string Lossless { get; set; }
            public string CBR_BitMode { get; set; }
            public string CBR { get; set; }
            public string VBR_BitMode { get; set; }
            public string VBR { get; set; }
            //public string Custom { get; set; }
        }
        public List<AudioQuality> _Audio_Quality_Items = new List<AudioQuality>();
        public List<AudioQuality> Audio_Quality_Items
        {
            get { return _Audio_Quality_Items; }
            set
            {
                _Audio_Quality_Items = value;
                OnPropertyChanged("Audio_Quality_Items");
            }
        }

        // Selected Index
        private int _Audio_Quality_SelectedIndex { get; set; }
        public int Audio_Quality_SelectedIndex
        {
            get { return _Audio_Quality_SelectedIndex; }
            set
            {
                if (_Audio_Quality_SelectedIndex == value)
                {
                    return;
                }

                _Audio_Quality_SelectedIndex = value;
                OnPropertyChanged("Audio_Quality_SelectedIndex");
            }
        }

        // Selected Item
        public string _Audio_Quality_SelectedItem { get; set; }
        public string Audio_Quality_SelectedItem
        {
            get { return _Audio_Quality_SelectedItem; }
            set
            {
                var previousItem = _Audio_Quality_SelectedItem;
                _Audio_Quality_SelectedItem = value;
                OnPropertyChanged("Audio_Quality_SelectedItem");

                if (previousItem != value)
                {
                    AudioControls.AutoCopyAudioCodec(this);
                }

                //if (_Audio_Quality_SelectedItem == value)
                //{
                //    return;
                //}

                //_Audio_Quality_SelectedItem = value;
                //OnPropertyChanged("Audio_Quality_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_Quality_IsEnabled = true;
        public bool Audio_Quality_IsEnabled
        {
            get { return _Audio_Quality_IsEnabled; }
            set
            {
                if (_Audio_Quality_IsEnabled == value)
                {
                    return;
                }

                _Audio_Quality_IsEnabled = value;
                OnPropertyChanged("Audio_Quality_IsEnabled");
            }
        }


        // -------------------------
        // Audio Bitrate
        // -------------------------
        // Text
        private string _Audio_Bitrate_Text;
        public string Audio_Bitrate_Text
        {
            get { return _Audio_Bitrate_Text; }
            set
            {
                if (_Audio_Bitrate_Text == value)
                {
                    return;
                }

                _Audio_Bitrate_Text = value;
                OnPropertyChanged("Audio_Bitrate_Text");
            }
        }
        // Enabled
        private bool _Audio_Bitrate_IsEnabled = true;
        public bool Audio_Bitrate_IsEnabled
        {
            get { return _Audio_Bitrate_IsEnabled; }
            set
            {
                if (_Audio_Bitrate_IsEnabled == value)
                {
                    return;
                }

                _Audio_Bitrate_IsEnabled = value;
                OnPropertyChanged("Audio_Bitrate_IsEnabled");
            }
        }


        // -------------------------
        // Audio VBR - Toggle
        // -------------------------
        // Checked
        private bool _Audio_VBR_IsChecked;
        public bool Audio_VBR_IsChecked
        {
            get { return _Audio_VBR_IsChecked; }
            set
            {
                if (_Audio_VBR_IsChecked != value)
                {
                    _Audio_VBR_IsChecked = value;
                    OnPropertyChanged("Audio_VBR_IsChecked");
                }
            }
        }

        // Enabled
        private bool _Audio_VBR_IsEnabled = true;
        public bool Audio_VBR_IsEnabled
        {
            get { return _Audio_VBR_IsEnabled; }
            set
            {
                if (_Audio_VBR_IsEnabled == value)
                {
                    return;
                }

                _Audio_VBR_IsEnabled = value;
                OnPropertyChanged("Audio_VBR_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Audio Sample Rate
        // --------------------------------------------------
        // Items Source
        public class AudioSampleRate
        {
            public string Name { get; set; }
            public string Frequency { get; set; }
        }
        public List<AudioSampleRate> _Audio_SampleRate_Items = new List<AudioSampleRate>();
        public List<AudioSampleRate> Audio_SampleRate_Items
        {
            get { return _Audio_SampleRate_Items; }
            set
            {
                _Audio_SampleRate_Items = value;
                OnPropertyChanged("Audio_SampleRate_Items");
            }
        }

        // Selected Index
        private int _Audio_SampleRate_SelectedIndex { get; set; }
        public int Audio_SampleRate_SelectedIndex
        {
            get { return _Audio_SampleRate_SelectedIndex; }
            set
            {
                if (_Audio_SampleRate_SelectedIndex == value)
                {
                    return;
                }

                _Audio_SampleRate_SelectedIndex = value;
                OnPropertyChanged("Audio_SampleRate_SelectedIndex");
            }
        }

        // Selected Item
        private string _Audio_SampleRate_SelectedItem { get; set; }
        public string Audio_SampleRate_SelectedItem
        {
            get { return _Audio_SampleRate_SelectedItem; }
            set
            {
                var previousItem = _Audio_SampleRate_SelectedItem;
                _Audio_SampleRate_SelectedItem = value;
                OnPropertyChanged("Audio_SampleRate_SelectedItem");

                if (previousItem != value)
                {
                    AudioControls.AutoCopyAudioCodec(this);
                }

                //if (_Audio_SampleRate_SelectedItem == value)
                //{
                //    return;
                //}

                //_Audio_SampleRate_SelectedItem = value;
                //OnPropertyChanged("Audio_SampleRate_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_SampleRate_IsEnabled = true;
        public bool Audio_SampleRate_IsEnabled
        {
            get { return _Audio_SampleRate_IsEnabled; }
            set
            {
                if (_Audio_SampleRate_IsEnabled == value)
                {
                    return;
                }

                _Audio_SampleRate_IsEnabled = value;
                OnPropertyChanged("Audio_SampleRate_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Audio Bit Depth
        // --------------------------------------------------
        // Items Source
        public class AudioBitDepth
        {
            public string Name { get; set; }
            public string Depth { get; set; }
        }
        public List<AudioBitDepth> _Audio_BitDepth_Items = new List<AudioBitDepth>();
        public List<AudioBitDepth> Audio_BitDepth_Items
        {
            get { return _Audio_BitDepth_Items; }
            set
            {
                _Audio_BitDepth_Items = value;
                OnPropertyChanged("Audio_BitDepth_Items");
            }
        }

        // Selected Index
        private int _Audio_BitDepth_SelectedIndex { get; set; }
        public int Audio_BitDepth_SelectedIndex
        {
            get { return _Audio_BitDepth_SelectedIndex; }
            set
            {
                if (_Audio_BitDepth_SelectedIndex == value)
                {
                    return;
                }

                _Audio_BitDepth_SelectedIndex = value;
                OnPropertyChanged("Audio_BitDepth_SelectedIndex");
            }
        }

        // Selected Item
        private string _Audio_BitDepth_SelectedItem { get; set; }
        public string Audio_BitDepth_SelectedItem
        {
            get { return _Audio_BitDepth_SelectedItem; }
            set
            {
                var previousItem = _Audio_BitDepth_SelectedItem;
                _Audio_BitDepth_SelectedItem = value;
                OnPropertyChanged("Audio_BitDepth_SelectedItem");

                if (previousItem != value)
                {
                    AudioControls.AutoCopyAudioCodec(this);
                }

                //if (_Audio_BitDepth_SelectedItem == value)
                //{
                //    return;
                //}

                //_Audio_BitDepth_SelectedItem = value;
                //OnPropertyChanged("Audio_BitDepth_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Audio_BitDepth_IsEnabled = true;
        public bool Audio_BitDepth_IsEnabled
        {
            get { return _Audio_BitDepth_IsEnabled; }
            set
            {
                if (_Audio_BitDepth_IsEnabled == value)
                {
                    return;
                }

                _Audio_BitDepth_IsEnabled = value;
                OnPropertyChanged("Audio_BitDepth_IsEnabled");
            }
        }


        // -------------------------
        // Volume
        // -------------------------
        // Text
        private string _Audio_Volume_Text = "100";
        public string Audio_Volume_Text
        {
            get { return _Audio_Volume_Text; }
            set
            {
                if (_Audio_Volume_Text == value)
                {
                    return;
                }

                _Audio_Volume_Text = value;
                OnPropertyChanged("Audio_Volume_Text");
            }
        }
        // Enabled
        private bool _Audio_Volume_IsEnabled = true;
        public bool Audio_Volume_IsEnabled
        {
            get { return _Audio_Volume_IsEnabled; }
            set
            {
                if (_Audio_Volume_IsEnabled == value)
                {
                    return;
                }

                _Audio_Volume_IsEnabled = value;
                OnPropertyChanged("Audio_Volume_IsEnabled");
            }
        }


        // -------------------------
        // Hard Limiter
        // -------------------------
        // Value
        private double _Audio_HardLimiter_Value = 1;
        public double Audio_HardLimiter_Value
        {
            get { return _Audio_HardLimiter_Value; }
            set
            {
                if (_Audio_HardLimiter_Value == value)
                {
                    return;
                }

                _Audio_HardLimiter_Value = value;
                OnPropertyChanged("Audio_HardLimiter_Value");
            }
        }

        // Enabled
        private bool _Audio_HardLimiter_IsEnabled = true;
        public bool Audio_HardLimiter_IsEnabled
        {
            get { return _Audio_HardLimiter_IsEnabled; }
            set
            {
                if (_Audio_HardLimiter_IsEnabled == value)
                {
                    return;
                }

                _Audio_HardLimiter_IsEnabled = value;
                OnPropertyChanged("Audio_HardLimiter_IsEnabled");
            }
        }


        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Configure
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // -------------------------
        // FFmpeg Path
        // -------------------------
        // Text
        private string _FFmpegPath_Text;
        public string FFmpegPath_Text
        {
            get { return _FFmpegPath_Text; }
            set
            {
                if (_FFmpegPath_Text == value)
                {
                    return;
                }

                _FFmpegPath_Text = value;
                OnPropertyChanged("FFmpegPath_Text");
            }
        }
        // Enabled
        private bool _FFmpegPath_IsEnabled = true;
        public bool FFmpegPath_IsEnabled
        {
            get { return _FFmpegPath_IsEnabled; }
            set
            {
                if (_FFmpegPath_IsEnabled == value)
                {
                    return;
                }

                _FFmpegPath_IsEnabled = value;
                OnPropertyChanged("FFmpegPath_IsEnabled");
            }
        }

        // -------------------------
        // FFprobe Path
        // -------------------------
        // Text
        private string _FFprobePath_Text;
        public string FFprobePath_Text
        {
            get { return _FFprobePath_Text; }
            set
            {
                if (_FFprobePath_Text == value)
                {
                    return;
                }

                _FFprobePath_Text = value;
                OnPropertyChanged("FFprobePath_Text");
            }
        }
        // Enabled
        private bool _FFprobePath_IsEnabled = true;
        public bool FFprobePath_IsEnabled
        {
            get { return _FFprobePath_IsEnabled; }
            set
            {
                if (_FFprobePath_IsEnabled == value)
                {
                    return;
                }

                _FFprobePath_IsEnabled = value;
                OnPropertyChanged("FFprobePath_IsEnabled");
            }
        }

        // -------------------------
        // FFplay Path
        // -------------------------
        // Text
        private string _FFplayPath_Text;
        public string FFplayPath_Text
        {
            get { return _FFplayPath_Text; }
            set
            {
                if (_FFplayPath_Text == value)
                {
                    return;
                }

                _FFplayPath_Text = value;
                OnPropertyChanged("FFplayPath_Text");
            }
        }
        // Enabled
        private bool _FFplayPath_IsEnabled = true;
        public bool FFplayPath_IsEnabled
        {
            get { return _FFplayPath_IsEnabled; }
            set
            {
                if (_FFplayPath_IsEnabled == value)
                {
                    return;
                }

                _FFplayPath_IsEnabled = value;
                OnPropertyChanged("FFplayPath_IsEnabled");
            }
        }


        // -------------------------
        // Log Console
        // -------------------------
        // Text
        private string _LogConsole_Text;
        public string LogConsole_Text
        {
            get { return _LogConsole_Text; }
            set
            {
                if (_LogConsole_Text == value)
                {
                    return;
                }

                _LogConsole_Text = value;
                OnPropertyChanged("LogConsole_Text");
            }
        }


        // -------------------------
        // Log Path
        // -------------------------
        // Text
        private string _LogPath_Text;
        public string LogPath_Text
        {
            get { return _LogPath_Text; }
            set
            {
                if (_LogPath_Text == value)
                {
                    return;
                }

                _LogPath_Text = value;
                OnPropertyChanged("LogPath_Text");
            }
        }
        // Enabled
        private bool _LogPath_IsEnabled = true;
        public bool LogPath_IsEnabled
        {
            get { return _LogPath_IsEnabled; }
            set
            {
                if (_LogPath_IsEnabled == value)
                {
                    return;
                }

                _LogPath_IsEnabled = value;
                OnPropertyChanged("LogPath_IsEnabled");
            }
        }

        // -------------------------
        // Log - CheckBox
        // -------------------------
        // Checked
        private bool _LogCheckBox_IsChecked;
        public bool LogCheckBox_IsChecked
        {
            get { return _LogCheckBox_IsChecked; }
            set
            {
                if (_LogCheckBox_IsChecked != value)
                {
                    _LogCheckBox_IsChecked = value;
                    OnPropertyChanged("LogCheckBox_IsChecked");
                }
            }
        }
        // Enabled
        private bool _LogCheckBox_IsEnabled = true;
        public bool LogCheckBox_IsEnabled
        {
            get { return _LogCheckBox_IsEnabled; }
            set
            {
                if (_LogCheckBox_IsEnabled == value)
                {
                    return;
                }

                _LogCheckBox_IsEnabled = value;
                OnPropertyChanged("LogCheckBox_IsEnabled");
            }
        }

        // --------------------------------------------------
        // Threads
        // --------------------------------------------------
        // Items Source
        private List<string> _Threads_Items = new List<string>()
        {
           "default",
           "optimal",
           "all",
           "1",
           "2",
           "3",
           "4",
           "5",
           "6",
           "7",
           "8",
           "9",
           "10",
           "11",
           "12",
           "13",
           "14",
           "15",
           "16"
        };
        public List<string> Threads_Items
        {
            get { return _Threads_Items; }
            set
            {
                _Threads_Items = value;
                OnPropertyChanged("Threads_Items");
            }
        }

        // Selected Index
        private int _Threads_SelectedIndex { get; set; }
        public int Threads_SelectedIndex
        {
            get { return _Threads_SelectedIndex; }
            set
            {
                if (_Threads_SelectedIndex == value)
                {
                    return;
                }

                _Threads_SelectedIndex = value;
                OnPropertyChanged("Threads_SelectedIndex");
            }
        }

        // Selected Item
        private string _Threads_SelectedItem { get; set; }
        public string Threads_SelectedItem
        {
            get { return _Threads_SelectedItem; }
            set
            {
                if (_Threads_SelectedItem == value)
                {
                    return;
                }

                _Threads_SelectedItem = value;
                OnPropertyChanged("Threads_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Threads_IsEnabled = true;
        public bool Threads_IsEnabled
        {
            get { return _Threads_IsEnabled; }
            set
            {
                if (_Threads_IsEnabled == value)
                {
                    return;
                }

                _Threads_IsEnabled = value;
                OnPropertyChanged("Threads_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Theme
        // --------------------------------------------------
        // Items Source
        private List<string> _Theme_Items = new List<string>()
        {
            "Axiom",
            "FFmpeg",
            "Cyberpunk",
            "Onyx",
            "Circuit",
            "System"
        };
        public List<string> Theme_Items
        {
            get { return _Theme_Items; }
            set
            {
                _Theme_Items = value;
                OnPropertyChanged("Theme_Items");
            }
        }

        // Selected Index
        private int _Theme_SelectedIndex { get; set; }
        public int Theme_SelectedIndex
        {
            get { return _Theme_SelectedIndex; }
            set
            {
                if (_Theme_SelectedIndex == value)
                {
                    return;
                }

                _Theme_SelectedIndex = value;
                OnPropertyChanged("Theme_SelectedIndex");
            }
        }

        // Selected Item
        private string _Theme_SelectedItem { get; set; }
        public string Theme_SelectedItem
        {
            get { return _Theme_SelectedItem; }
            set
            {
                if (_Theme_SelectedItem == value)
                {
                    return;
                }

                _Theme_SelectedItem = value;
                OnPropertyChanged("Theme_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Theme_IsEnabled = true;
        public bool Theme_IsEnabled
        {
            get { return _Theme_IsEnabled; }
            set
            {
                if (_Theme_IsEnabled == value)
                {
                    return;
                }

                _Theme_IsEnabled = value;
                OnPropertyChanged("Theme_IsEnabled");
            }
        }


        // -------------------------
        // Update Auto Check - Toggle
        // -------------------------
        // Checked
        private bool _UpdateAutoCheck_IsChecked;
        public bool UpdateAutoCheck_IsChecked
        {
            get { return _UpdateAutoCheck_IsChecked; }
            set
            {
                if (_UpdateAutoCheck_IsChecked != value)
                {
                    _UpdateAutoCheck_IsChecked = value;
                    OnPropertyChanged("UpdateAutoCheck_IsChecked");
                }
            }
        }

        // Enabled
        private bool _UpdateAutoCheck_IsEnabled = true;
        public bool UpdateAutoCheck_IsEnabled
        {
            get { return _UpdateAutoCheck_IsEnabled; }
            set
            {
                if (_UpdateAutoCheck_IsEnabled == value)
                {
                    return;
                }

                _UpdateAutoCheck_IsEnabled = value;
                OnPropertyChanged("UpdateAutoCheck_IsEnabled");
            }
        }




        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Subtitle
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------
        // Subtitle Codec
        // --------------------------------------------------
        // Items Source
        public List<string> _Subtitle_Codec_Items = new List<string>();
        public List<string> Subtitle_Codec_Items
        {
            get { return _Subtitle_Codec_Items; }
            set
            {
                _Subtitle_Codec_Items = value;
                OnPropertyChanged("Subtitle_Codec_Items");
            }
        }

        // Codec and Parameters
        public class SubtitleCodec
        {
            public string Codec { get; set; }
            public string Parameters { get; set; }
        }

        // Codec Command
        public string Subtitle_Codec;

        // Selected Index
        public int _Subtitle_Codec_SelectedIndex { get; set; }
        public int Subtitle_Codec_SelectedIndex
        {
            get { return _Subtitle_Codec_SelectedIndex; }
            set
            {
                if (_Subtitle_Codec_SelectedIndex == value)
                {
                    return;
                }

                _Subtitle_Codec_SelectedIndex = value;
                OnPropertyChanged("Subtitle_Codec_SelectedIndex");
            }
        }

        // Selected Item
        public string _Subtitle_Codec_SelectedItem { get; set; }
        public string Subtitle_Codec_SelectedItem
        {
            get { return _Subtitle_Codec_SelectedItem; }
            set
            {
                if (_Subtitle_Codec_SelectedItem == value)
                {
                    return;
                }

                _Subtitle_Codec_SelectedItem = value;
                OnPropertyChanged("Subtitle_Codec_SelectedItem");
            }
        }

        // Controls Enable
        public bool _Subtitle_Codec_IsEnabled = true;
        public bool Subtitle_Codec_IsEnabled
        {
            get { return _Subtitle_Codec_IsEnabled; }
            set
            {
                if (_Subtitle_Codec_IsEnabled == value)
                {
                    return;
                }

                _Subtitle_Codec_IsEnabled = value;
                OnPropertyChanged("Subtitle_Codec_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Subtitle Stream
        // --------------------------------------------------
        // Items Source
        public List<string> _Subtitle_Stream_Items = new List<string>();
        public List<string> Subtitle_Stream_Items
        {
            get { return _Subtitle_Stream_Items; }
            set
            {
                _Subtitle_Stream_Items = value;
                OnPropertyChanged("Subtitle_Stream_Items");
            }
        }

        // Selected Index
        public int _Subtitle_Stream_SelectedIndex { get; set; }
        public int Subtitle_Stream_SelectedIndex
        {
            get { return _Subtitle_Stream_SelectedIndex; }
            set
            {
                if (_Subtitle_Stream_SelectedIndex == value)
                {
                    return;
                }

                _Subtitle_Stream_SelectedIndex = value;
                OnPropertyChanged("Subtitle_Stream_SelectedIndex");
            }
        }

        // Selected Item
        public string _Subtitle_Stream_SelectedItem { get; set; }
        public string Subtitle_Stream_SelectedItem
        {
            get { return _Subtitle_Stream_SelectedItem; }
            set
            {
                if (_Subtitle_Stream_SelectedItem == value)
                {
                    return;
                }

                _Subtitle_Stream_SelectedItem = value;
                OnPropertyChanged("Subtitle_Stream_SelectedItem");
            }
        }

        // Controls Enable
        public bool _Subtitle_Stream_IsEnabled = true;
        public bool Subtitle_Stream_IsEnabled
        {
            get { return _Subtitle_Stream_IsEnabled; }
            set
            {
                if (_Subtitle_Stream_IsEnabled == value)
                {
                    return;
                }

                _Subtitle_Stream_IsEnabled = value;
                OnPropertyChanged("Subtitle_Stream_IsEnabled");
            }
        }



        // --------------------------------------------------
        // Subtitle ListView
        // --------------------------------------------------
        // Items Source
        private ObservableCollection<string> _Subtitle_ListView_Items = new ObservableCollection<string>();
        public ObservableCollection<string> Subtitle_ListView_Items
        {
            get { return _Subtitle_ListView_Items; }
            set
            {
                _Subtitle_ListView_Items = value;
                OnPropertyChanged("Subtitle_ListView_Items");
            }
        }
        // Selected Items
        private List<string> _Subtitle_ListView_SelectedItems = new List<string>();
        public List<string> Subtitle_ListView_SelectedItems
        {
            get { return _Subtitle_ListView_SelectedItems; }
            set
            {
                _Subtitle_ListView_SelectedItems = value;
                OnPropertyChanged("Subtitle_ListView_SelectedItems");
            }
        }
        // Selected Idnex
        private int _Subtitle_ListView_SelectedIndex { get; set; }
        public int Subtitle_ListView_SelectedIndex
        {
            get { return _Subtitle_ListView_SelectedIndex; }
            set
            {
                if (_Subtitle_ListView_SelectedIndex == value)
                {
                    return;
                }

                _Subtitle_ListView_SelectedIndex = value;
                OnPropertyChanged("Subtitle_ListView_SelectedIndex");
            }
        }
        // Controls Enable
        public bool _Subtitle_ListView_IsEnabled = true;
        public bool Subtitle_ListView_IsEnabled
        {
            get { return _Subtitle_ListView_IsEnabled; }
            set
            {
                if (_Subtitle_ListView_IsEnabled == value)
                {
                    return;
                }

                _Subtitle_ListView_IsEnabled = value;
                OnPropertyChanged("Subtitle_ListView_IsEnabled");
            }
        }


        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Filters
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------------------------------------------------------------
        // Video
        // --------------------------------------------------------------------------------------------------------

        // -------------------------
        // Deband
        // -------------------------
        // -------------------------
        // Deband
        // -------------------------
        // Items
        public static List<string> _FilterVideo_Deband_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterVideo_Deband_Items
        {
            get { return _FilterVideo_Deband_Items; }
            set { _FilterVideo_Deband_Items = value; }
        }

        // Selected Item
        private string _FilterVideo_Deband_SelectedItem { get; set; }
        public string FilterVideo_Deband_SelectedItem
        {
            get { return _FilterVideo_Deband_SelectedItem; }
            set
            {
                if (_FilterVideo_Deband_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_Deband_SelectedItem = value;
                OnPropertyChanged("FilterVideo_Deband_SelectedItem");
            }
        }

        // -------------------------
        // Deshake
        // -------------------------
        // Items
        public static List<string> _FilterVideo_Deshake_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterVideo_Deshake_Items
        {
            get { return _FilterVideo_Deshake_Items; }
            set { _FilterVideo_Deshake_Items = value; }
        }

        // Selected Item
        private string _FilterVideo_Deshake_SelectedItem { get; set; }
        public string FilterVideo_Deshake_SelectedItem
        {
            get { return _FilterVideo_Deshake_SelectedItem; }
            set
            {
                if (_FilterVideo_Deshake_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_Deshake_SelectedItem = value;
                OnPropertyChanged("FilterVideo_Deshake_SelectedItem");
            }
        }


        // -------------------------
        // Deflicker
        // -------------------------
        // Items
        public static List<string> _FilterVideo_Deflicker_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterVideo_Deflicker_Items
        {
            get { return _FilterVideo_Deflicker_Items; }
            set { _FilterVideo_Deflicker_Items = value; }
        }
        // Selected Item
        private string _FilterVideo_Deflicker_SelectedItem { get; set; }
        public string FilterVideo_Deflicker_SelectedItem
        {
            get { return _FilterVideo_Deflicker_SelectedItem; }
            set
            {
                if (_FilterVideo_Deflicker_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_Deflicker_SelectedItem = value;
                OnPropertyChanged("FilterVideo_Deflicker_SelectedItem");
            }
        }


        // -------------------------
        // Dejudder
        // -------------------------
        // Items
        public static List<string> _FilterVideo_Dejudder_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterVideo_Dejudder_Items
        {
            get { return _FilterVideo_Dejudder_Items; }
            set { _FilterVideo_Dejudder_Items = value; }
        }
        // Selected Item
        private string _FilterVideo_Dejudder_SelectedItem { get; set; }
        public string FilterVideo_Dejudder_SelectedItem
        {
            get { return _FilterVideo_Dejudder_SelectedItem; }
            set
            {
                if (_FilterVideo_Dejudder_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_Dejudder_SelectedItem = value;
                OnPropertyChanged("FilterVideo_Dejudder_SelectedItem");
            }
        }

        // -------------------------
        // Denoise
        // -------------------------
        // Items
        public static List<string> _FilterVideo_Denoise_Items = new List<string>()
        {
            "disabled",
            "default",
            "light",
            "medium",
            "heavy",
        };
        public static List<string> FilterVideo_Denoise_Items
        {
            get { return _FilterVideo_Denoise_Items; }
            set { _FilterVideo_Denoise_Items = value; }
        }
        // Selected Item
        private string _FilterVideo_Denoise_SelectedItem { get; set; }
        public string FilterVideo_Denoise_SelectedItem
        {
            get { return _FilterVideo_Denoise_SelectedItem; }
            set
            {
                if (_FilterVideo_Denoise_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_Denoise_SelectedItem = value;
                OnPropertyChanged("FilterVideo_Denoise_SelectedItem");
            }
        }


        // -------------------------
        // EQ Brightness
        // -------------------------
        // Value
        private double _FilterVideo_EQ_Brightness_Value = 0;
        public double FilterVideo_EQ_Brightness_Value
        {
            get { return _FilterVideo_EQ_Brightness_Value; }
            set
            {
                if (_FilterVideo_EQ_Brightness_Value == value)
                {
                    return;
                }

                _FilterVideo_EQ_Brightness_Value = value;
                OnPropertyChanged("FilterVideo_EQ_Brightness_Value");
            }
        }

        // -------------------------
        // EQ Contrast
        // -------------------------
        // Value
        private double _FilterVideo_EQ_Contrast_Value = 0;
        public double FilterVideo_EQ_Contrast_Value
        {
            get { return _FilterVideo_EQ_Contrast_Value; }
            set
            {
                if (_FilterVideo_EQ_Contrast_Value == value)
                {
                    return;
                }

                _FilterVideo_EQ_Contrast_Value = value;
                OnPropertyChanged("FilterVideo_EQ_Contrast_Value");
            }
        }

        // -------------------------
        // EQ Saturation
        // -------------------------
        // Value
        private double _FilterVideo_EQ_Saturation_Value = 0;
        public double FilterVideo_EQ_Saturation_Value
        {
            get { return _FilterVideo_EQ_Saturation_Value; }
            set
            {
                if (_FilterVideo_EQ_Saturation_Value == value)
                {
                    return;
                }

                _FilterVideo_EQ_Saturation_Value = value;
                OnPropertyChanged("FilterVideo_EQ_Saturation_Value");
            }
        }

        // -------------------------
        // EQ Gamma
        // -------------------------
        // Value
        private double _FilterVideo_EQ_Gamma_Value = 0;
        public double FilterVideo_EQ_Gamma_Value
        {
            get { return _FilterVideo_EQ_Gamma_Value; }
            set
            {
                if (_FilterVideo_EQ_Gamma_Value == value)
                {
                    return;
                }

                _FilterVideo_EQ_Gamma_Value = value;
                OnPropertyChanged("FilterVideo_EQ_Gamma_Value");
            }
        }


        // -------------------------
        // Selective Color
        // -------------------------
        // -------------------------
        // Correction Method
        // -------------------------
        // Items
        public static List<string> _FilterVideo_SelectiveColor_Correction_Method_Items = new List<string>()
        {
            "relative",
            "absolute"
        };
        public static List<string> FilterVideo_SelectiveColor_Correction_Method_Items
        {
            get { return _FilterVideo_SelectiveColor_Correction_Method_Items; }
            set { _FilterVideo_SelectiveColor_Correction_Method_Items = value; }
        }

        // Selected Item
        private string _FilterVideo_SelectiveColor_Correction_Method_SelectedItem { get; set; }
        public string FilterVideo_SelectiveColor_Correction_Method_SelectedItem
        {
            get { return _FilterVideo_SelectiveColor_Correction_Method_SelectedItem; }
            set
            {
                if (_FilterVideo_SelectiveColor_Correction_Method_SelectedItem == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Correction_Method_SelectedItem = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Correction_Method_SelectedItem");
            }
        }


        // --------------------------------------------------
        // Reds
        // --------------------------------------------------
        // -------------------------
        // Reds Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Reds_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Reds_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Reds_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Reds_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Reds_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Reds_Cyan_Value");
            }
        }

        // -------------------------
        // Reds Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Reds_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Reds_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Reds_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Reds_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Reds_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Reds_Magenta_Value");
            }
        }

        // -------------------------
        // Reds Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Reds_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Reds_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Reds_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Reds_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Reds_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Reds_Yellow_Value");
            }
        }


        // --------------------------------------------------
        // Yellows
        // --------------------------------------------------
        // -------------------------
        // Yellows Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Yellows_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Yellows_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Yellows_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Yellows_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Yellows_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Yellows_Cyan_Value");
            }
        }

        // -------------------------
        // Yellows Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Yellows_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Yellows_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Yellows_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Yellows_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Yellows_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Yellows_Magenta_Value");
            }
        }

        // -------------------------
        // Yellows Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Yellows_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Yellows_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Yellows_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Yellows_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Yellows_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Yellows_Yellow_Value");
            }
        }


        // --------------------------------------------------
        // Greens
        // --------------------------------------------------
        // -------------------------
        // Greens Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Greens_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Greens_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Greens_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Greens_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Greens_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Greens_Cyan_Value");
            }
        }

        // -------------------------
        // Greens Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Greens_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Greens_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Greens_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Greens_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Greens_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Greens_Magenta_Value");
            }
        }

        // -------------------------
        // Greens Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Greens_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Greens_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Greens_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Greens_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Greens_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Greens_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Cyans
        // --------------------------------------------------
        // -------------------------
        // Cyans Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Cyans_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Cyans_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Cyans_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Cyans_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Cyans_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Cyans_Cyan_Value");
            }
        }

        // -------------------------
        // Cyans Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Cyans_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Cyans_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Cyans_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Cyans_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Cyans_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Cyans_Magenta_Value");
            }
        }

        // -------------------------
        // Cyans Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Cyans_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Cyans_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Cyans_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Cyans_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Cyans_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Cyans_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Blues
        // --------------------------------------------------
        // -------------------------
        // Blues Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blues_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Blues_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Blues_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blues_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blues_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blues_Cyan_Value");
            }
        }

        // -------------------------
        // Blues Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blues_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Blues_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Blues_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blues_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blues_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blues_Magenta_Value");
            }
        }

        // -------------------------
        // Blues Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blues_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Blues_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Blues_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blues_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blues_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blues_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Magentas
        // --------------------------------------------------
        // -------------------------
        // Magentas Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Magentas_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Magentas_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Magentas_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Magentas_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Magentas_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Magentas_Cyan_Value");
            }
        }

        // -------------------------
        // Magentas Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Magentas_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Magentas_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Magentas_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Magentas_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Magentas_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Magentas_Magenta_Value");
            }
        }

        // -------------------------
        // Magentas Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Magentas_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Magentas_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Magentas_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Magentas_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Magentas_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Magentas_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Whites
        // --------------------------------------------------
        // -------------------------
        // Whites Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Whites_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Whites_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Whites_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Whites_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Whites_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Whites_Cyan_Value");
            }
        }

        // -------------------------
        // Whites Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Whites_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Whites_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Whites_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Whites_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Whites_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Whites_Magenta_Value");
            }
        }

        // -------------------------
        // Whites Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Whites_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Whites_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Whites_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Whites_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Whites_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Whites_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Neutrals
        // --------------------------------------------------
        // -------------------------
        // Neutrals Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Neutrals_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Neutrals_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Neutrals_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Neutrals_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Neutrals_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Neutrals_Cyan_Value");
            }
        }

        // -------------------------
        // Neutrals Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Neutrals_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Neutrals_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Neutrals_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Neutrals_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Neutrals_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Neutrals_Magenta_Value");
            }
        }

        // -------------------------
        // Neutrals Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Neutrals_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Neutrals_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Neutrals_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Neutrals_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Neutrals_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Neutrals_Yellow_Value");
            }
        }

        // --------------------------------------------------
        // Blacks
        // --------------------------------------------------
        // -------------------------
        // Blacks Cyan
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blacks_Cyan_Value = 0;
        public double FilterVideo_SelectiveColor_Blacks_Cyan_Value
        {
            get { return _FilterVideo_SelectiveColor_Blacks_Cyan_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blacks_Cyan_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blacks_Cyan_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blacks_Cyan_Value");
            }
        }

        // -------------------------
        // Blacks Magenta
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blacks_Magenta_Value = 0;
        public double FilterVideo_SelectiveColor_Blacks_Magenta_Value
        {
            get { return _FilterVideo_SelectiveColor_Blacks_Magenta_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blacks_Magenta_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blacks_Magenta_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blacks_Magenta_Value");
            }
        }

        // -------------------------
        // Blacks Yellow
        // -------------------------
        // Value
        private double _FilterVideo_SelectiveColor_Blacks_Yellow_Value = 0;
        public double FilterVideo_SelectiveColor_Blacks_Yellow_Value
        {
            get { return _FilterVideo_SelectiveColor_Blacks_Yellow_Value; }
            set
            {
                if (_FilterVideo_SelectiveColor_Blacks_Yellow_Value == value)
                {
                    return;
                }

                _FilterVideo_SelectiveColor_Blacks_Yellow_Value = value;
                OnPropertyChanged("FilterVideo_SelectiveColor_Blacks_Yellow_Value");
            }
        }



        // --------------------------------------------------------------------------------------------------------
        // Audio
        // --------------------------------------------------------------------------------------------------------
        // -------------------------
        // Lowpass
        // -------------------------
        // Items
        public static List<string> _FilterAudio_Lowpass_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterAudio_Lowpass_Items
        {
            get { return _FilterAudio_Lowpass_Items; }
            set { _FilterAudio_Lowpass_Items = value; }
        }

        // Selected Item
        private string _FilterAudio_Lowpass_SelectedItem { get; set; }
        public string FilterAudio_Lowpass_SelectedItem
        {
            get { return _FilterAudio_Lowpass_SelectedItem; }
            set
            {
                if (_FilterAudio_Lowpass_SelectedItem == value)
                {
                    return;
                }

                _FilterAudio_Lowpass_SelectedItem = value;
                OnPropertyChanged("FilterAudio_Lowpass_SelectedItem");
            }
        }

        // -------------------------
        // Highpass
        // -------------------------
        // Items
        public static List<string> _FilterAudio_Highpass_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterAudio_Highpass_Items
        {
            get { return _FilterAudio_Highpass_Items; }
            set { _FilterAudio_Highpass_Items = value; }
        }
        // Selected Item
        private string _FilterAudio_Highpass_SelectedItem { get; set; }
        public string FilterAudio_Highpass_SelectedItem
        {
            get { return _FilterAudio_Highpass_SelectedItem; }
            set
            {
                if (_FilterAudio_Highpass_SelectedItem == value)
                {
                    return;
                }

                _FilterAudio_Highpass_SelectedItem = value;
                OnPropertyChanged("FilterAudio_Highpass_SelectedItem");
            }
        }

        // -------------------------
        // Headphones (Earwax)
        // -------------------------
        // Items
        public static List<string> _FilterAudio_Headphones_Items = new List<string>()
        {
            "disabled",
            "enabled"
        };
        public static List<string> FilterAudio_Headphones_Items
        {
            get { return _FilterAudio_Headphones_Items; }
            set { _FilterAudio_Headphones_Items = value; }
        }

        // Selected Item
        private string _FilterAudio_Headphones_SelectedItem { get; set; }
        public string FilterAudio_Headphones_SelectedItem
        {
            get { return _FilterAudio_Headphones_SelectedItem; }
            set
            {
                if (_FilterAudio_Headphones_SelectedItem == value)
                {
                    return;
                }

                _FilterAudio_Headphones_SelectedItem = value;
                OnPropertyChanged("FilterAudio_Headphones_SelectedItem");
            }
        }

        // -------------------------
        // Contrast
        // -------------------------
        // Value
        private double _FilterAudio_Contrast_Value = 0;
        public double FilterAudio_Contrast_Value
        {
            get { return _FilterAudio_Contrast_Value; }
            set
            {
                if (_FilterAudio_Contrast_Value == value)
                {
                    return;
                }

                _FilterAudio_Contrast_Value = value;
                OnPropertyChanged("FilterAudio_Contrast_Value");
            }
        }

        // -------------------------
        // Extra Stereo
        // -------------------------
        // Value
        private double _FilterAudio_ExtraStereo_Value = 0;
        public double FilterAudio_ExtraStereo_Value
        {
            get { return _FilterAudio_ExtraStereo_Value; }
            set
            {
                if (_FilterAudio_ExtraStereo_Value == value)
                {
                    return;
                }

                _FilterAudio_ExtraStereo_Value = value;
                OnPropertyChanged("FilterAudio_ExtraStereo_Value");
            }
        }

        // -------------------------
        // Tempo
        // -------------------------
        // Value
        private double _FilterAudio_Tempo_Value = 100;
        public double FilterAudio_Tempo_Value
        {
            get { return _FilterAudio_Tempo_Value; }
            set
            {
                if (_FilterAudio_Tempo_Value == value)
                {
                    return;
                }

                _FilterAudio_Tempo_Value = value;
                OnPropertyChanged("FilterAudio_Tempo_Value");
            }
        }


    }
}
