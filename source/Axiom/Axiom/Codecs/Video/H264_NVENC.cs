/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2021 Matt McManis
https://github.com/MattMcManis/Axiom
https://axiomui.github.io
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

using Axiom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Controls.Video.Codec
{
    public class H264_NVENC : Controls.IVideoCodec
    {
        // ---------------------------------------------------------------------------
        // Codec
        // ---------------------------------------------------------------------------
        public ObservableCollection<ViewModel.Video.VideoCodec> codec { get; set; } = new ObservableCollection<ViewModel.Video.VideoCodec>()
        {
            new ViewModel.Video.VideoCodec() { Codec = "h264_nvenc", Parameters = "" }
        };


        // ---------------------------------------------------------------------------
        // Items Source
        // ---------------------------------------------------------------------------

        // -------------------------
        // Encode Speed
        // -------------------------
        public ObservableCollection<ViewModel.Video.VideoEncodeSpeed> encodeSpeed { get; set; } = new ObservableCollection<ViewModel.Video.VideoEncodeSpeed>()
        {
            new ViewModel.Video.VideoEncodeSpeed() { Name = "none",            Command = ""},
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Default",         Command = "-preset default" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Lossless",        Command = "-preset lossless" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Lossless HP",     Command = "-preset losslesshp" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Slow",            Command = "-preset slow" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Medium",          Command = "-preset medium" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Fast",            Command = "-preset fast" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "HP",              Command = "-preset hp" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "HQ",              Command = "-preset hq" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "BD",              Command = "-preset hq" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Low Latency",     Command = "-preset ll" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Low Latency HP",  Command = "-preset llhp" },
            new ViewModel.Video.VideoEncodeSpeed() { Name = "Low Latency HQ",  Command = "-preset llhq" },
        };

        // -------------------------
        // Pixel Format
        // -------------------------
        public ObservableCollection<string> pixelFormat { get; set; } = new ObservableCollection<string>()
        {
            "auto",
            "yuv420p",
            "nv12",
            "p010le",
            "yuv444p",
            "yuv444p16le",
            "bgr0",
            "rgb0",
            "cuda",
            "d3d11"
        };

        // -------------------------
        // Quality
        // -------------------------
        public ObservableCollection<ViewModel.Video.VideoQuality> quality { get; set; } = new ObservableCollection<ViewModel.Video.VideoQuality>()
        {
            new ViewModel.Video.VideoQuality() { Name = "Auto",      CRF = "",   CRF_HWAccel_Intel_QSV = "",   CRF_HWAccel_NVIDIA_NVENC = "",   CBR_BitMode = "-b:v", CBR = "",      VBR_BitMode = "-q:v", VBR = "",      MinRate = "", MaxRate = "", BufSize ="", NA = "3000K" },
            new ViewModel.Video.VideoQuality() { Name = "Lossless",  CRF = "",   CRF_HWAccel_Intel_QSV = "",   CRF_HWAccel_NVIDIA_NVENC = "",   CBR_BitMode = "",     CBR = "",      VBR_BitMode = "",     VBR = "",      MinRate = "", MaxRate = "", BufSize ="", Lossless = "-qp 0" },
            new ViewModel.Video.VideoQuality() { Name = "Ultra",     CRF = "16", CRF_HWAccel_Intel_QSV = "18", CRF_HWAccel_NVIDIA_NVENC = "19", CBR_BitMode = "-b:v", CBR = "5000K", VBR_BitMode = "-q:v", VBR = "5000K", MinRate = "", MaxRate = "", BufSize ="" },
            new ViewModel.Video.VideoQuality() { Name = "High",      CRF = "20", CRF_HWAccel_Intel_QSV = "22", CRF_HWAccel_NVIDIA_NVENC = "23", CBR_BitMode = "-b:v", CBR = "2500K", VBR_BitMode = "-q:v", VBR = "2500K", MinRate = "", MaxRate = "", BufSize ="" },
            new ViewModel.Video.VideoQuality() { Name = "Medium",    CRF = "25", CRF_HWAccel_Intel_QSV = "27", CRF_HWAccel_NVIDIA_NVENC = "28", CBR_BitMode = "-b:v", CBR = "1300K", VBR_BitMode = "-q:v", VBR = "1300K", MinRate = "", MaxRate = "", BufSize ="" },
            new ViewModel.Video.VideoQuality() { Name = "Low",       CRF = "35", CRF_HWAccel_Intel_QSV = "37", CRF_HWAccel_NVIDIA_NVENC = "38", CBR_BitMode = "-b:v", CBR = "600K",  VBR_BitMode = "-q:v", VBR = "600K",  MinRate = "", MaxRate = "", BufSize ="" },
            new ViewModel.Video.VideoQuality() { Name = "Sub",       CRF = "45", CRF_HWAccel_Intel_QSV = "47", CRF_HWAccel_NVIDIA_NVENC = "48", CBR_BitMode = "-b:v", CBR = "250K",  VBR_BitMode = "-q:v", VBR = "250K",  MinRate = "", MaxRate = "", BufSize ="" },
            new ViewModel.Video.VideoQuality() { Name = "Custom",    CRF = "",   CRF_HWAccel_Intel_QSV = "",   CRF_HWAccel_NVIDIA_NVENC = "",   CBR_BitMode = "-b:v", CBR = "",      VBR_BitMode = "-q:v", VBR = "",      MinRate = "", MaxRate = "", BufSize ="" }
        };

        // -------------------------
        // Pass
        // -------------------------
        public void EncodingPass()
        {
            // -------------------------
            // Quality
            // -------------------------
            switch (VM.VideoView.Video_Quality_SelectedItem)
            {
                // Auto
                case "Auto":
                    VM.VideoView.Video_Pass_Items = new ObservableCollection<string>()
                    {
                        "2 Pass"
                    };

                    VM.VideoView.Video_Pass_SelectedItem = "2 Pass";
                    VM.VideoView.Video_Pass_IsEnabled = false;
                    Controls.passUserSelected = false;
                    VM.VideoView.Video_CRF_IsEnabled = false;
                    break;

                // Lossless
                case "Lossless":
                    VM.VideoView.Video_Pass_Items = new ObservableCollection<string>()
                    {
                        "1 Pass"
                    };

                    VM.VideoView.Video_Pass_SelectedItem = "1 Pass";
                    VM.VideoView.Video_Pass_IsEnabled = true;
                    VM.VideoView.Video_CRF_IsEnabled = false;
                    break;

                // Custom
                case "Custom":
                    VM.VideoView.Video_Pass_Items = new ObservableCollection<string>()
                    {
                        "CRF",
                        "1 Pass",
                        "2 Pass"
                    };

                    VM.VideoView.Video_Pass_IsEnabled = true;
                    VM.VideoView.Video_CRF_IsEnabled = true;
                    break;

                // None
                case "None":
                    VM.VideoView.Video_Pass_Items = new ObservableCollection<string>()
                    {
                        "auto"
                    };

                    VM.VideoView.Video_Pass_IsEnabled = false;
                    VM.VideoView.Video_CRF_IsEnabled = false;
                    break;

                // Presets: Ultra, High, Medium, Low, Sub
                default:
                    VM.VideoView.Video_Pass_Items = new ObservableCollection<string>()
                    {
                        "CRF",
                        "1 Pass",
                        "2 Pass"
                    };

                    VM.VideoView.Video_Pass_IsEnabled = true;
                    VM.VideoView.Video_CRF_IsEnabled = false;

                    // Default to CRF
                    if (Controls.passUserSelected == false)
                    {
                        VM.VideoView.Video_Pass_SelectedItem = "CRF";
                        Controls.passUserSelected = true;
                    }
                    break;
            }

            // Clear TextBoxes
            if (VM.VideoView.Video_Quality_SelectedItem == "Auto" ||
                VM.VideoView.Video_Quality_SelectedItem == "Lossless" ||
                VM.VideoView.Video_Quality_SelectedItem == "Custom" ||
                VM.VideoView.Video_Quality_SelectedItem == "None"
                )
            {
                VM.VideoView.Video_CRF_Text = string.Empty;
                VM.VideoView.Video_BitRate_Text = string.Empty;
                VM.VideoView.Video_MinRate_Text = string.Empty;
                VM.VideoView.Video_MaxRate_Text = string.Empty;
                VM.VideoView.Video_BufSize_Text = string.Empty;
            }
        }


        // -------------------------
        // Optimize
        // -------------------------
        public ObservableCollection<ViewModel.Video.VideoOptimize> optimize { get; set; } = new ObservableCollection<ViewModel.Video.VideoOptimize>()
        {
            new ViewModel.Video.VideoOptimize() { Name = "None",      Tune = "none",      Profile = "none",     Level = "none", Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Custom",    Tune = "none",      Profile = "none",     Level = "none", Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Web",       Tune = "none",      Profile = "baseline", Level = "3.0",  Command = "-movflags +faststart" },
            new ViewModel.Video.VideoOptimize() { Name = "Animation", Tune = "animation", Profile = "main",     Level = "4.1",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "PC HD",     Tune = "none",      Profile = "high",     Level = "4.2",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "PC SD",     Tune = "none",      Profile = "baseline", Level = "3.1",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Blu-ray",   Tune = "none",      Profile = "none",     Level = "none", Command = "-deblock 0:0 -H264_NVENC-params " + MainWindow.WrapWithQuotes("bluray-compat=1:level=4.1:open-gop=1:slices=4:colorprim=bt709:colormatrix=bt709:vbv-maxrate=40000:vbv-bufsize=30000:me=umh:ref=4:nal-hrd=vbr:aud=1:b-pyramid=strict") },
            new ViewModel.Video.VideoOptimize() { Name = "Windows",   Tune = "none",      Profile = "baseline", Level = "3.1",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Apple",     Tune = "none",      Profile = "baseline", Level = "3.1",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Android",   Tune = "none",      Profile = "baseline", Level = "3.0",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "PS3",       Tune = "none",      Profile = "main",     Level = "4.0",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "PS4",       Tune = "none",      Profile = "high",     Level = "4.1",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Xbox 360",  Tune = "none",      Profile = "main",     Level = "4.0",  Command = "" },
            new ViewModel.Video.VideoOptimize() { Name = "Xbox One",  Tune = "none",      Profile = "high",     Level = "4.1",  Command = "" }
        };

        // -------------------------
        // Tune
        // -------------------------
        public ObservableCollection<string> tune { get; set; } = new ObservableCollection<string>()
        {
            "none",
            "film",
            "animation",
            "grain",
            "stillimage",
            "fastdecode",
            "zerolatency"
        };

        // -------------------------
        // Profile
        // -------------------------
        public ObservableCollection<string> profile { get; set; } = new ObservableCollection<string>()
        {
            "none",
            "baseline",
            "main",
            "high",
            "high444p"
        };

        // -------------------------
        // Level
        // -------------------------
        public ObservableCollection<string> level { get; set; } = new ObservableCollection<string>()
        {
            "none",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "2.0",
            "2.2",
            "2.2",
            "3.0",
            "3.1",
            "3.2",
            "4.0",
            "4.1",
            "4.2",
            "5.0",
            "5.1",
            "5.2"
        };


        // ---------------------------------------------------------------------------
        // Controls Behavior
        // ---------------------------------------------------------------------------

        // -------------------------
        // Selected Items
        // -------------------------
        public List<ViewModel.Video.Selected> controls_Selected { get; set; } = new List<ViewModel.Video.Selected>()
        {
            new ViewModel.Video.Selected()
            {
                PixelFormat_Lossless = "yuv444p",
                PixelFormat = "yuv420p"
            },
        };

        // -------------------------
        // Expanded
        // -------------------------
        public List<ViewModel.Video.Expanded> controls_Expanded { get; set; } = new List<ViewModel.Video.Expanded>()
        {
            new ViewModel.Video.Expanded() {  Optimize = true },
        };

        // -------------------------
        // Checked
        // -------------------------
        public List<ViewModel.Video.Checked> controls_Checked { get; set; } = new List<ViewModel.Video.Checked>()
        {
            new ViewModel.Video.Checked() {  VBR = false },
        };

        // -------------------------
        // Enabled
        // -------------------------
        public List<ViewModel.Video.Enabled> controls_Enabled { get; set; } = new List<ViewModel.Video.Enabled>()
        {
            new ViewModel.Video.Enabled()
            {
                Quality =   true,
                VBR =       true,
                Optimize =  true
            },
            
            // All other controls are set through Format.Controls.MediaTypeControls()
        };

    }
}
