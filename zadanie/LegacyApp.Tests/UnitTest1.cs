namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }
    
 
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail(){
          // Arrange
                var userService = new UserService();
        
                // Act
                var result = userService.AddUser(
                    "Jan", 
                    "Kowalski", 
                    "kowalskikowalskipl",
                    DateTime.Parse("2000-01-01"),
                    1
                );
        
                // Assert
                // Assert.Equal(false, result);
                Assert.False(result);
    }
   
     [Fact]
        public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld(){
              // Arrange
                    var userService = new UserService();
            
                    // Act
                    var result = userService.AddUser(
                        "Jan", 
                        "Kowalski", 
                        "kowalski@kowalski.pl",
                        DateTime.Parse("2010-01-01"),
                        1
                    );
            
                    // Assert
                    // Assert.Equal(false, result);
                    Assert.False(result);
        }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient(){
          // Arrange
                var userService = new UserService();
        
                // Act 
                var result = userService.AddUser(
                    "Jan", 
                    "Malewski", 
                    "malewski@gmail.pl",
                    DateTime.Parse("2000-01-01"),
                    2
                );
      
        
                // Assert
              
                Assert.True(result);
    }
   
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient(){
              // Arrange
                    var userService = new UserService();
            
                    // Act             

                    var result = userService.AddUser(
                        "Jan", 
                        "Smith", 
                        "smith@gmail.pl",
                        DateTime.Parse("2000-01-01"),
                        3
                    );
          
            
                    // Assert
                  
                    Assert.True(result);
        }


    [Fact]
        public void AddUser_ReturnsTrueWhenNormalClient(){
                  // Arrange
                        var userService = new UserService();
                
                        // Act             
    
                        var result = userService.AddUser(
                            "Jan", 
                            "Kowalski", 
                            "kowalski@gmail.pl",
                            DateTime.Parse("2000-01-01"),
                            1
                        );
              
                
                        // Assert
                      
                        Assert.True(result);
            }
    
 
     [Fact]
            public void AddUser_ThrowsExceptionWhenUserDoesNotExist(){
                      // Arrange
                            var userService = new UserService();
                    
                            // Act             
        
                       
                  
                    
                            // Assert
                          Assert.Throws<ArgumentException> (() => 
                userService.AddUser(
                                                "Jan", 
                                                "Nowak", 
                                                "kowalski@gmail.pl",
                                                DateTime.Parse("2000-01-01"),
                                                9
                                            ));
                              
                            
                }
 
    
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}