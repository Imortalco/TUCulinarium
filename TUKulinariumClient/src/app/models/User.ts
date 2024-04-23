export class User {
  private UserName: string;
  private Email: string;
  private Password: string;
  private ConfirmPassword: string;
  private FirstName: string;
  private LastName: string;
  private PhoneNumber: string;
  private Address: string;

  constructor(
    username: string,
    email: string,
    password: string,
    confirmPassword: string,
    firstName: string,
    lastName: string,
    phone: string,
    address: string
  ) {
    this.UserName = username;
    this.Email = email;
    this.Password = password;
    this.ConfirmPassword = confirmPassword;
    this.FirstName = firstName;
    this.LastName = lastName;
    this.PhoneNumber = phone;
    this.Address = address;
  }
}
