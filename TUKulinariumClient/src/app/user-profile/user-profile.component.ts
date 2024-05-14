import { Component } from '@angular/core';
import { User } from '../models/User';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { UserProfile } from '../models/UserProfile';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent {
  username: string;
  profileForm: FormGroup;
  userProfileData: UserProfile;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {
    this.username = localStorage.getItem('username');
    this.authService.getUserProfile(this.username).subscribe((data) => {
      this.userProfileData = data;
    });
    this.profileForm = this.formBuilder.group({
      username: [this.userProfileData.UserName, Validators.required],
      firstName: [this.userProfileData.FirstName, Validators.required],
      lastName: [this.userProfileData.LastName, Validators.required],
      email: [
        this.userProfileData.Email,
        [Validators.required, Validators.email],
      ],
      phoneNumber: [
        this.userProfileData.PhoneNumber,
        Validators.pattern(/^(\+\d{1,3})?\s?(\d{3,})$/),
      ],
      address: [this.userProfileData.Address, Validators.required],
    });
  }

  onSave(): void {
    this.userProfileData = this.profileForm.value;
    this.authService.updateUserProfile(this.userProfileData);
  }
}
