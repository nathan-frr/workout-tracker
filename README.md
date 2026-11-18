# workout-tracker
This is a personal project to develop a fully functional PWA that works as a workout tracker to log all workouts and see your personal history.

## Status

This project is not deployed yet. It can be run locally:

1. Start PostgreSQL with Docker:

   ```bash
   cp .env.example .env
   docker compose up -d
   ```

2. Start the backend:

   ```bash
   dotnet run --project backend/src/WorkoutTracker.Api
   ```

3. In a second terminal, start the frontend:

   ```bash
   cd frontend/workout-tracker
   npm install
   npm start
   ```

4. Open `http://localhost:4200` in your browser.
