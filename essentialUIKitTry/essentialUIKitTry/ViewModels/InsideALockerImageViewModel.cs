﻿using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace essentialUIKitTry.ViewModels
{
    /// <summary>
    /// ViewModel for something went wrong page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class InsideALockerImageViewModel : BaseViewModel
    {
        #region Fields

        private static InsideALockerImageViewModel somethingWentWrongPageViewModel;

        private string imagePath;

        private string header;

        private string content;

        private Command tryAgainCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="InsideALockerImageViewModel" /> class.
        /// </summary>
        public InsideALockerImageViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of something went wrong page view model.
        /// </summary>
        public static InsideALockerImageViewModel BindingContext =>
            somethingWentWrongPageViewModel = PopulateData<InsideALockerImageViewModel>("errorAndEmpty.json");

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        [DataMember(Name = "somethingWentWrongImagePath")]
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.SetProperty(ref this.imagePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        [DataMember(Name = "somethingWentWrongHeader")]
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                this.SetProperty(ref this.header, value);
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        [DataMember(Name = "somethingWentWrongContent")]
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.SetProperty(ref this.content, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the TryAgain button is clicked.
        /// </summary>
        public Command TryAgainCommand
        {
            get
            {
                return this.tryAgainCommand ?? (this.tryAgainCommand = new Command(this.TryAgain));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "essentialUIKitTry.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        /// <summary>
        /// Invoked when the TryAgain button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void TryAgain(object obj)
        {
            // Do something
        }

        #endregion
    }
}
