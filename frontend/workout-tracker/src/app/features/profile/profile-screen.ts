import { Component } from '@angular/core';

@Component({
  selector: 'app-profile-screen',
  template: `
    <section class="profile-screen" aria-labelledby="profile-heading">
      <h1 id="profile-heading">Profile</h1>
      <p>Your profile settings will appear here.</p>
    </section>
  `,
})
export class ProfileScreen {}