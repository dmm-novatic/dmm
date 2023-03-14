import { Subject } from 'rxjs';
import { filter } from 'rxjs/operators';

const alertSubject = new Subject();
const defaultId = 'default-alert';

export const alertService = {
  onAlert,
  success,
  error,
  standard,
  warn,
  premium,
  alert,
  clear,
};

export const alertType = {
  success: 'success',
  error: 'error',
  standard: 'standard',
  warning: 'warning',
  premium: 'premium',
};

// enable subscribing to alerts observable
function onAlert(id = defaultId) {
  return alertSubject.asObservable().pipe(filter((x) => x && x.id === id));
}

// convenience methods
function success(message, options) {
  alert({ ...options, type: alertType.success, message });
}

function error(message, options) {
  alert({ ...options, type: alertType.error, message });
}

function standard(message, options) {
  alert({ ...options, type: alertType.standard, message });
}

function warn(message, options) {
  alert({ ...options, type: alertType.warning, message });
}

function premium(message, options) {
  alert({ ...options, type: alertType.premium, message });
}

// core alert method
function alert(alert) {
  alert.id = alert.id || defaultId;
  alertSubject.next(alert);
}

// clear alerts
function clear(id = defaultId) {
  alertSubject.next({ id });
}
