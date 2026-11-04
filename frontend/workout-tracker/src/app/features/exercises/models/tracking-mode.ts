export enum TrackingMode {
    RepsAndWeight = 'RepsAndWeight',
    Reps = 'Reps',
    Duration = 'Duration',
    DurationAndWeight = 'DurationAndWeight',
    Distance = 'Distance',
    DistanceAndWeight = 'DistanceAndWeight',
    DurationAndDistance = 'DurationAndDistance',
}

export type TrackingField = 'reps' | 'weight' | 'duration' | 'distance';

export const TRACKING_MODE_FIELDS: Record<TrackingMode, TrackingField[]> = {
  [TrackingMode.RepsAndWeight]: ['reps', 'weight'],
  [TrackingMode.Reps]: ['reps'],
  [TrackingMode.Duration]: ['duration'],
  [TrackingMode.DurationAndWeight]: ['duration', 'weight'],
  [TrackingMode.Distance]: ['distance'],
  [TrackingMode.DistanceAndWeight]: ['distance', 'weight'],
  [TrackingMode.DurationAndDistance]: ['duration', 'distance'],
};