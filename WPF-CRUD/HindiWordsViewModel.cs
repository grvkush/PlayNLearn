using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_CRUD
{
    public class HindiWordsViewModel : INotifyPropertyChanged
    {
        AzureSpeechService azureSpeechService;
        public ObservableCollection<HindiLetter> HindiConsonants { get; set; }
        public ObservableCollection<HindiLetter> HindiVowels { get; set; }
        public ObservableCollection<HindiLetter> HindiMatras { get; set; }
        public ObservableCollection<ImageData> Images { get; set; }
        public ObservableCollection<string> ImageCategories { get; set; }
        private Stack<string> wordHistory = new Stack<string>();
        PlaySoundsHelper playSoundsHelper;


        #region PropertyChangedEventHandler_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Event generated command methods
        public ICommand MouseMoveCommand { get; }
        public ICommand MouseDownCommand { get; }

        #endregion
        public HindiWordsViewModel()
        {
            azureSpeechService = new AzureSpeechService();
            playSoundsHelper = new PlaySoundsHelper();

            HindiConsonants = new ObservableCollection<HindiLetter>()
            {
                new HindiLetter() { Letter = "क", Name = "क" },
                new HindiLetter() { Letter = "ख", Name = "ख" },
                new HindiLetter() { Letter = "ग", Name = "ग" },
                new HindiLetter() { Letter = "घ", Name = "घ" },
                new HindiLetter() { Letter = "ङ", Name = "ङ" },
                new HindiLetter() { Letter = "च", Name = "च" },
                new HindiLetter() { Letter = "छ", Name = "छ" },
                new HindiLetter() { Letter = "ज", Name = "ज" },
                new HindiLetter() { Letter = "झ", Name = "झ" },
                new HindiLetter() { Letter = "ञ", Name = "ञ" },
                new HindiLetter() { Letter = "ट", Name = "ट" },
                new HindiLetter() { Letter = "ठ", Name = "ठ" },
                new HindiLetter() { Letter = "ड", Name = "ड" },
                new HindiLetter() { Letter = "ढ", Name = "ढ" },
                new HindiLetter() { Letter = "ण", Name = "ण" },
                new HindiLetter() { Letter = "त", Name = "त" },
                new HindiLetter() { Letter = "थ", Name = "थ" },
                new HindiLetter() { Letter = "द", Name = "द" },
                new HindiLetter() { Letter = "ध", Name = "ध" },
                new HindiLetter() { Letter = "न", Name = "न" },
                new HindiLetter() { Letter = "प", Name = "प" },
                new HindiLetter() { Letter = "फ", Name = "फ" },
                new HindiLetter() { Letter = "ब", Name = "ब" },
                new HindiLetter() { Letter = "भ", Name = "भ" },
                new HindiLetter() { Letter = "म", Name = "म" },
                new HindiLetter() { Letter = "य", Name = "य" },
                new HindiLetter() { Letter = "र", Name = "र" },
                new HindiLetter() { Letter = "ल", Name = "ल" },
                new HindiLetter() { Letter = "व", Name = "व" },
                new HindiLetter() { Letter = "श", Name = "श" },
                new HindiLetter() { Letter = "ष", Name = "ष" },
                new HindiLetter() { Letter = "स", Name = "स" },
                new HindiLetter() { Letter = "ह", Name = "ह" },
                new HindiLetter() { Letter = "क्ष", Name = "क्ष" },
                new HindiLetter() { Letter = "त्र", Name = "त्र" },
                new HindiLetter() { Letter = "ज्ञ", Name = "ज्ञ" },
                new HindiLetter() { Letter = "श्र", Name = "श्र" },
                new HindiLetter() { Letter = "ड़", Name = "ड़" },
                new HindiLetter() { Letter = "ढ़", Name = "ढ़" },
                new HindiLetter() { Letter = "ह्र", Name = "ह्र" },
                new HindiLetter() { Letter = "क्ष्म", Name = "क्ष्म" },
                new HindiLetter() { Letter = "त्र्य", Name = "त्र्य" },
                new HindiLetter() { Letter = "ज्ञ्य", Name = "ज्ञ्य" },
                new HindiLetter() { Letter = "श्र्य", Name = "श्र्य" },
                new HindiLetter() { Letter = "ह्र्य", Name = "ह्र्य" }
            };

            HindiVowels = new ObservableCollection<HindiLetter>()
            {
                new HindiLetter()
                {
                    Letter="अ",
                    Name="अ"
                },
                new HindiLetter()
                {
                    Letter= "आ",
                    Name= "आ"
                },
                new HindiLetter()
                {
                    Letter=  "इ",
                    Name=  "इ"
                },
                new HindiLetter()
                {
                    Letter= "ई",
                    Name= "ई"
                },
                new HindiLetter()
                {
                    Letter= "उ",
                    Name= "उ"
                },

                new HindiLetter()
                {
                    Letter= "ऊ",
                    Name= "ऊ"
                },

                new HindiLetter()
                {
                    Letter= "ऋ",
                    Name= "ऋ"
                },

                new HindiLetter()
                {
                    Letter= "ए",
                    Name= "ए"
                },

                new HindiLetter()
                {
                    Letter= "ऐ",
                    Name= "ऐ"
                },
                new HindiLetter()
                {
                    Letter= "ओ",
                    Name= "ओ"
                },
                new HindiLetter()
                {
                    Letter= "औ",
                    Name= "औ"
                },
                new HindiLetter()
                {
                    Letter= "अं",
                    Name= "अं"
                },
                new HindiLetter()
                {
                    Letter= "अः",
                    Name= "अः"
                },
                new HindiLetter()
                {
                    Letter= "अँ",
                    Name= "अँ"
                }
            };

            HindiMatras = new ObservableCollection<HindiLetter>()
            {
                new HindiLetter()
                {
                    Letter = "\u094D",
                    ImagePath = "/Images/Matras/Aadha.png",
                    Name = "Aadha",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ा",
                    ImagePath = "/Images/Matras/Aa.png",
                    Name = "Aa",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ि",
                    ImagePath = "/Images/Matras/E.png",
                    Name = "E",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ी",
                    ImagePath = "/Images/Matras/Ee.png",
                    Name = "Ee",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ु",
                    ImagePath = "/Images/Matras/U.png",
                    Name = "U.png",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ू",
                    ImagePath = "/Images/Matras/Uu.png",
                    Name = "Uu",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ृ",
                    ImagePath = "/Images/Matras/Ri.png",
                    Name = "Ri",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "े",
                    ImagePath = "/Images/Matras/A.png",
                    Name = "A",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ै",
                    ImagePath = "/Images/Matras/Aye.png",
                    Name = "Aye",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ो",
                    ImagePath = "/Images/Matras/O.png",
                    Name = "O",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ौ",
                    ImagePath = "/Images/Matras/Au.png",
                    Name = "Au",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ं",
                    ImagePath = "/Images/Matras/Ang.png",
                    Name = "Ang",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ः",
                    ImagePath = "/Images/Matras/Aha.png",
                    Name = "Aha",
                    HasImage = true
                },
                new HindiLetter()
                {
                    Letter = "ँ",
                    ImagePath = "/Images/Matras/Ch.png",
                    Name = "Ch",
                    HasImage = true
                }
            };

            Images = new ObservableCollection<ImageData>()
            {
                // Empty image data for default selection
                new ImageData()
                {
                    ImagePath = "/Images/Category/NoImage.png",
                    Name = "NoImage",
                    Category = "",
                    Description = "Please select an image from the categories.",
                    HindiName = ""
                },
                #region Category: Animal (cow, lion, rhino, sheep, tiger, wolf)
                new ImageData()
                    {
                        ImagePath = "/Images/Category/Animals/cow.png",
                        Name = "Cow",
                        Category = "Animal",
                        Description = "A domestic cow",
                        HindiName = "गाय"
                    },
                new ImageData()
                {
                    ImagePath = "/Images/Category/Animals/lion.png",
                    Name = "Lion",
                    Category = "Animal",
                    Description = "The king of the jungle",
                    HindiName = "शेर"
                },
                new ImageData()
                {
                    ImagePath = "/Images/Category/Animals/rhino.png",
                    Name = "Rhinoceros",
                    Category = "Animal",
                    Description = "A big fat rhino",
                    HindiName = "गैंडा"
                },
                new ImageData()
                {
                    ImagePath = "/Images/Category/Animals/sheep.png",
                    Name = "Sheep",
                    Category = "Animal",
                    Description = "A fluffy sheep",
                    HindiName = "भेड़"
                },
                new ImageData()
                {
                    ImagePath = "/Images/Category/Animals/tiger.png",
                    Name = "Tiger",
                    Category = "Animal",
                    Description = "A fierce tiger",
                    HindiName = "बाघ"
                },
                new ImageData()
                {
                    ImagePath = "/Images/Category/Animals/wolf.png",
                    Name = "Wolf",
                    Category = "Animal",
                    Description = "A wild wolf",
                    HindiName = "भेड़िया"
                },
                #endregion

                #region Category: Bird (crow, peacock, pigeon, parrot)
                new ImageData()
                {
                    ImagePath = "/Images/Category/Birds/crow.png",
                    Name = "Crow",
                    Category = "Bird",
                    Description = "A black crow",
                    HindiName = "कौआ"
                },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Birds/peacock.png",
                        Name = "Peacock",
                        Category = "Bird",
                        Description = "A colorful peacock",
                        HindiName = "मोर"
                    },
                    new ImageData()
                        {
                            ImagePath = "/Images/Category/Birds/pigeon.png",
                            Name = "Pigeon",
                            Category = "Bird",
                            Description = "A common pigeon",
                            HindiName = "कबूतर"
                        },
                    new ImageData()
                        {
                            ImagePath = "/Images/Category/Birds/parrot.png",
                            Name = "Parrot",
                            Category = "Bird",
                            Description = "A talking parrot",
                            HindiName = "तोता"
                        },
                #endregion

                #region Category: Flower (rose, marigold, lotus, lily, hibiscus)
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Flowers/rose.png",
                        Name = "Rose",
                        Category = "Flower",
                        Description = "A red rose",
                        HindiName = "गुलाब"
                    },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Flowers/marigold.png",
                        Name = "Marigold",
                        Category = "Flower",
                        Description = "A bright marigold",
                        HindiName = "गेंदा"
                    },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Flowers/lotus.png",
                        Name = "Lotus",
                        Category = "Flower",
                        Description = "A sacred lotus",
                        HindiName = "कमल"
                    },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Flowers/lily.png",
                        Name = "Lily",
                        Category = "Flower",
                        Description = "A white lily",
                        HindiName = "कुमुदिनी"
                    },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Flowers/hibiscus.png",
                            Name = "Hibiscus",
                            Category = "Flower",
                            Description = "A tropical hibiscus",
                            HindiName = "गुड़हल"
                        },
                #endregion

                #region Category: Fruit (apple, banana, coconut, grapes, kiwi, mango, muskmelon, orange, pomegranate, watermelon )
                    new ImageData()
                {
                    ImagePath = "/Images/Category/Fruits/apple.png",
                    Name = "Apple",
                    Category = "Fruit",
                    Description = "A red apple",
                    HindiName = "सेब"
                },
                    new ImageData()
                {
                    ImagePath = "/Images/Category/Fruits/banana.png",
                    Name = "Banana",
                    Category = "Fruit",
                    Description = "A ripe banana",
                    HindiName = "केला"
                },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Fruits/coconut.png",
                        Name = "Coconut",
                        Category = "Fruit",
                        Description = "A tropical coconut",
                        HindiName = "नारियल"
                    },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Fruits/grapes.png",
                        Name = "Grapes",
                        Category = "Fruit",
                        Description = "A bunch of grapes",
                        HindiName = "अंगूर"
                    },
                    new ImageData()
                    {
                        ImagePath = "/Images/Category/Fruits/kiwi.png",
                        Name = "Kiwi",
                        Category = "Fruit",
                        Description = "A fuzzy kiwi",
                        HindiName = "कीवी"
                    },
                    new ImageData()
                        {
                            ImagePath = "/Images/Category/Fruits/mango.png",
                            Name = "Mango",
                            Category = "Fruit",
                            Description = "A sweet mango",
                            HindiName = "आम"
                        },
                    new ImageData()
                            {
                                ImagePath = "/Images/Category/Fruits/muskmelon.png",
                                Name = "Muskmelon",
                                Category = "Fruit",
                                Description = "A juicy muskmelon",
                                HindiName = "खरबूजा"
                            },
                    new ImageData()
                                {
                                    ImagePath = "/Images/Category/Fruits/orange.png",
                                    Name = "Orange",
                                    Category = "Fruit",
                                    Description = "A citrus orange",
                                    HindiName = "संतरा"
                                },
                    new ImageData()
                                    {
                                        ImagePath = "/Images/Category/Fruits/pomegranate.png",
                                        Name = "Pomegranate",
                                        Category = "Fruit",
                                        Description = "A red pomegranate",
                                        HindiName = "अनार"
                                    },
                    new ImageData()
                                        {
                                            ImagePath = "/Images/Category/Fruits/watermelon.png",
                                            Name = "Watermelon",
                                            Category = "Fruit",
                                            Description = "A refreshing watermelon",
                                            HindiName = "तरबूज"
                                        },
                #endregion

                #region Category: Vegetable (carrot, cauliflower, garlic, onion, peas, potato, tomato)
                    new ImageData()
                    {
                    ImagePath = "/Images/Category/Vegetables/carrot.png",
                    Name = "Carrot",
                    Category = "Vegetable",
                    Description = "A crunchy carrot",
                    HindiName = "गाजर"
                     },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/cauliflower.png",
                        Name = "Cauliflower",
                        Category = "Vegetable",
                        Description = "A white cauliflower",
                        HindiName = "फूलगोभी"
                    },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/garlic.png",
                        Name = "Garlic",
                        Category = "Vegetable",
                        Description = "A pungent garlic",
                        HindiName = "लहसुन"
                    },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/onion.png",
                        Name = "Onion",
                        Category = "Vegetable",
                        Description = "A strong onion",
                        HindiName = "प्याज"
                    },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/peas.png",
                        Name = "Peas",
                        Category = "Vegetable",
                        Description = "A pod of peas",
                        HindiName = "मटर"
                    },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/potato.png",
                        Name = "Potato",
                        Category = "Vegetable",
                        Description = "A starchy potato",
                        HindiName = "आलू"
                    },
                        new ImageData()
                    {
                        ImagePath = "/Images/Category/Vegetables/tomato.png",
                        Name = "Tomato",
                        Category = "Vegetable",
                        Description = "A juicy tomato",
                        HindiName = "टमाटर"
                    },
                #endregion

                #region Category: Transport (bicycle, boat, bus, car, metro, motorcycle, ship, train)
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/bicycle.png",
                            Name = "Bicycle",
                            Category = "Transport",
                            Description = "A two-wheeled bicycle",
                            HindiName = "साइकिल"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/boat.png",
                            Name = "Boat",
                            Category = "Transport",
                            Description = "A small boat",
                            HindiName = "नाव"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/bus.png",
                            Name = "Bus",
                            Category = "Transport",
                            Description = "A public bus",
                            HindiName = "बस"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/car.png",
                            Name = "Car",
                            Category = "Transport",
                            Description = "A private car",
                            HindiName = "कार"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/metro.png",
                            Name = "Metro",
                            Category = "Transport",
                            Description = "An urban metro train",
                            HindiName = "मेट्रो"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/motorcycle.png",
                            Name = "Motorcycle",
                            Category = "Transport",
                            Description = "A fast motorcycle",
                            HindiName = "मोटरसाइकिल"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/ship.png",
                            Name = "Ship",
                            Category = "Transport",
                            Description = "A large ship",
                            HindiName = "जहाज"
                        },
                        new ImageData()
                        {
                            ImagePath = "/Images/Category/Transport/train.png",
                            Name = "Train",
                            Category = "Transport",
                            Description = "A long train",
                            HindiName = "ट्रेन"
                        }
                 #endregion
            };

            ImageCategories = new ObservableCollection<string>()
            {
                "Animal",
                "Bird",
                "Flower",
                "Fruit",
                "Vegetable",
                "Transport",
                "Clothing",
                "Electronics",
                "Food",
                "Furniture",
                "Household Items",
                "Musical Instruments",
                "Nature",
                "Office Supplies",
                "Personal Care Items",
                "Sports",
                "Tools"
            };

            SelectedCategory = ImageCategories.FirstOrDefault();

            Word = "";
            MainImage = Images.FirstOrDefault();

            copyToClipboardCommand = new RelayCommand(CopyToClipboardMethod);
            resetHindiWordCommand = new RelayCommand(ResetWord);
            undoHindiWordCommand = new RelayCommand(Undo);
            checkWordCommand = new RelayCommand(CheckWord);
            speakWordCommand = new RelayCommand(SpeakWord);
            showNameHintCommand = new RelayCommand(ShowNameHint);
        }

        #region Methods
        public void UpdateMainImage(ImageData imageData)
        {
            if (imageData != null)
            {
                MainImage = imageData;
            }
        }

        public void Append(string text)
        {
            SaveState();

            Word = $"{Word}{text}";
        }
        private void SaveState()
        {
            wordHistory.Push(Word);
        }

        private ObservableCollection<ImageData> FilterImages()
        {
            ObservableCollection<ImageData> imgs = new ObservableCollection<ImageData>();
            foreach (var item in Images)
            {
                if (item.Category == SelectedCategory)
                {
                    imgs.Add(item);
                }
            }
            return imgs;
        }

        private void OnCategoryChanged()
        {
            ShowImages = FilterImages();
        }

        #endregion

        #region CopyToClipboardCommand

        private RelayCommand copyToClipboardCommand;
        public RelayCommand CopyToClipboardCommand
        {
            get { return copyToClipboardCommand; }
        }

        public void CopyToClipboardMethod()
        {
            if (!String.IsNullOrEmpty(Word))
            {
                Clipboard.SetText(Word);
            }
        }
        #endregion

        #region ResetHindiWordCommand
        private RelayCommand resetHindiWordCommand;

        public RelayCommand ResetHindiWordCommand
        {
            get { return resetHindiWordCommand; }
        }

        private void ResetWord()
        {
            Word = "";
            wordHistory.Clear();
        }

        #endregion

        #region UndoHindiWordCommand

        private RelayCommand undoHindiWordCommand;

        public RelayCommand UndoHindiWordCommand
        {
            get { return undoHindiWordCommand; }
        }
        private void Undo()
        {
            if (wordHistory?.Count > 0)
            {
                Word = wordHistory.Pop();  
            }            
        }

        #endregion

        #region Check Word matches the image

        private RelayCommand checkWordCommand;

        public RelayCommand CheckWordCommand
        {
            get { return checkWordCommand; }
        }

        private void CheckWord()
        {
            if (MainImage != null && !String.IsNullOrEmpty(Word))
            {
                if (Word == MainImage.HindiName)
                {
                    playSoundsHelper.PlayCorrectSound();
                    PopUpMessage.Show(new PopUpData()
                    {
                        Title = "Correct",
                        Message = "That's correct!",
                        ImgPath = "/Images/Buttons/correct1.png",
                        Background = Brushes.Beige
                    });
                    
                }
                else
                {
                    playSoundsHelper.PlayWrongSound();
                    PopUpMessage.Show(new PopUpData()
                    {
                        Title = "Incorrect",
                        Message = "That's incorrect!",
                        ImgPath = "/Images/Buttons/wrong1.png",
                        Background = Brushes.Beige
                    });                    
                }
            }
            else
            {
                PopUpMessage.Show(new PopUpData
                {
                    Title = "Error",
                    Message = "Please select an image and enter a word.",
                    ImgPath = "/Images/Buttons/question1.png",
                    Background = Brushes.Beige
                });
            }
        }


        #endregion

        #region ShowNameHintCommand
        private RelayCommand showNameHintCommand;

        public RelayCommand ShowNameHintCommand
        {
            get { return showNameHintCommand; }
        }

        private void ShowNameHint()
        {
            if (MainImage != null && !string.IsNullOrEmpty(MainImage.HindiName))
            {
                PopUpMessage.Show(new PopUpData()
                {
                    Title = "Hint",
                    Message = $"' {MainImage.HindiName} '",
                    ImgPath = MainImage.ImagePath,
                    Background = Brushes.LightGreen,
                    ShowOkButton = false
                });
            }
        }

        #endregion

        #region SpeakWordCommand
        private RelayCommand speakWordCommand;

        public RelayCommand SpeakWordCommand
        {
            get { return speakWordCommand; }
        }

        private async void SpeakWord()
        {
            if (!string.IsNullOrEmpty(Word))
            {
                //await azureSpeechService.SpeakAsync(MainImage.HindiName);
                await azureSpeechService.SpeakAsync(Word);
            }
        }
        #endregion

        #region Properties
        private string word;
        public string Word
        {
            get { return word; }
            set 
            { 
                word = value; 
                OnPropertyChanged("Word");
            }
        }

        private ImageData mainImage;

        public ImageData MainImage
        {
            get { return mainImage; }
            set { mainImage = value; OnPropertyChanged("MainImage"); }
        }

        private string selectedCategory;
        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
                // On changing the category selection
                OnCategoryChanged();
            }
        }

        private ObservableCollection<ImageData> showImages;

        public ObservableCollection<ImageData> ShowImages
        {
            get { return showImages; }
            set { showImages = value; OnPropertyChanged("ShowImages"); }
        }

        #endregion

    }
    public class HindiLetter
    {
        public string Letter { get; set; }
        [DefaultValue("")]
        public string ImagePath { get; set; }
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool HasImage { get; set; }
    }

    public class ImageData
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }   
        public string Category { get; set; }
        public string Description { get; set; }
        [DefaultValue("No Hindi Name")]
        public string HindiName { get; set; }
    }
    public class PopUpData
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImgPath { get; set; }
        public SolidColorBrush Background { get; set; }
        public bool ShowOkButton { get; set; } = true;
    }
}
