
import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';

import {AuthResponse, LoginRequest, RegisterRequest} from './models/auth-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    private readonly http = inject(HttpClient);

    private readonly currentUserState = signal<AuthResponse | null>(null);
    private currentUserLoaded = false;

    readonly currentUser = this.currentUserState.asReadonly();

    readonly isAuthenticated = () => this.currentUserState() !== null;

    login(request: LoginRequest): Observable<AuthResponse> {
        return this.http
            .post<AuthResponse>('/api/auth/login', request)
            .pipe(
                tap(user => {
                    this.currentUserState.set(user);
                    this.currentUserLoaded = true;
                })
        );
    }

    register(request: RegisterRequest): Observable<AuthResponse> {
        return this.http
            .post<AuthResponse>('/api/auth/register', request)
            .pipe(
                tap(user => {
                    this.currentUserState.set(user);
                    this.currentUserLoaded = true;
                })
            );
    }

    logout(): Observable<void> {
        return this.http
            .post<void>('/api/auth/logout', {})
            .pipe(
                tap(() => {
                    this.currentUserState.set(null);
                    this.currentUserLoaded = true;
                })
            );
    }

    loadCurrentUser(): Observable<AuthResponse | null> {
        if (this.currentUserLoaded) {
            return of(this.currentUserState());
        }

        this.currentUserLoaded = true;

        return this.http
            .get<AuthResponse>('/api/auth/me')
            .pipe(
                tap(user => this.currentUserState.set(user)),
                catchError(() => {
                    this.currentUserState.set(null);
                    return of(null);
                })
            );
    }
}
