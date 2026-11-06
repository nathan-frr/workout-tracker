export enum TrackingMode {
    RepsAndWeight = 'RepsAndWeight',
    Reps = 'Reps',
    Duration = 'Duration',
    DurationAndWeight = 'DurationAndWeight',
    Distance = 'Distance',
    DistanceAndWeight = 'DistanceAndWeight',
    DurationAndDistance = 'DurationAndDistance',
}

export type TrackingField = 'reps' | 'weight' | 'durationInSeconds' | 'distanceInMeters';

export const TRACKING_MODE_FIELDS: Record<TrackingMode, TrackingField[]> = {
  [TrackingMode.RepsAndWeight]: ['reps', 'weight'],
  [TrackingMode.Reps]: ['reps'],
  [TrackingMode.Duration]: ['durationInSeconds'],
  [TrackingMode.DurationAndWeight]: ['durationInSeconds', 'weight'],
  [TrackingMode.Distance]: ['distanceInMeters'],
  [TrackingMode.DistanceAndWeight]: ['distanceInMeters', 'weight'],
  [TrackingMode.DurationAndDistance]: ['durationInSeconds', 'distanceInMeters'],
};