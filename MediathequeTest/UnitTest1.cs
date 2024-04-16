// Fichier: MediathequeServiceTests.cs
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Mediatheque.Core.Service.Tests
{
    [TestFixture]
    public class MediathequeServiceTests
    {
        [Test]
        public void PresentCDs_NoCDs_ReturnsNoCDMessage()
        {
            // Arrange
            var mockNotationService = new Mock<INotationService>();
            var mediathequeService = new MediathequeService(mockNotationService.Object);

            // Act
            var result = mediathequeService.PresentCDs();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Il n'y a pas de CD à afficher.", result[0]);
        }

        [Test]
        public void PresentCDs_WithCDs_ReturnsCDDescriptions()
        {
            // Arrange
            var mockNotationService = new Mock<INotationService>();
            mockNotationService.Setup(service => service.GetNoteAlbum(It.IsAny<string>())).Returns(4); // Remplacer 4 par la note désirée

            var mediathequeService = new MediathequeService(mockNotationService.Object);
            mediathequeService.AddObjet(new CD("Titre CD 1", "Groupe 1"));
            mediathequeService.AddObjet(new CD("Titre CD 2", "Groupe 2"));

            // Act
            var result = mediathequeService.PresentCDs();

            // Assert
            Assert.AreEqual(2, result.Count); // Vérifier le nombre de CDs retournés
            // Vérifier le format de la description du CD
            Assert.AreEqual("Groupe: Groupe 1 - Album: Titre CD 1 - Note: 4", result[0]);
            Assert.AreEqual("Groupe: Groupe 2 - Album: Titre CD 2 - Note: 4", result[1]);
        }
    }
}
