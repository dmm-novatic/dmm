import { notification } from 'antd';
class Utils {
    handleError(error) {
        if (error && error.toString() !== '') {
            notification['error']({
                message: 'Error',
                description: error.toString(),
            });
            return;
        }
    }
    handleSuccess(mess) {
        if ((mess && mess.toString() !== '') || (mess && mess.length > 0)) {
            notification['success']({
                message: 'Success',
                description: mess,
            });
            return;
        }
    }

    handleResponse(response) {
        const res = response.data;
        if (res.status) {
            const code = res.status;
            switch (Number(code)) {
                case 200: {
                    return res.data;
                }
                case 201: {
                    return res.data;
                }
                case 202: {
                    this.handleError(res.message);
                    break;
                }
                case 203: {
                    this.handleError(res.message);
                    break;
                }
                case 99: {
                    this.handleError(res.message);
                    break;
                }
                case 400: {
                    this.handleError(res.message);
                    break;
                }
                case 401: {
                    this.handleError(res.message);
                    break;
                }
                case 404: {
                    this.handleError(res.message);
                    break;
                }
                case 500: {
                    this.handleError(res.message);
                    break;
                }
                case 502: {
                    this.handleError(res.message);
                    break;
                }
                case 1000: {
                    this.handleError(res.message);
                    break;
                }
                case 1001: {
                    this.handleError(res.message);
                    break;
                }
                case 1002: {
                    this.handleError(res.message);
                    break;
                }
                default:
                    return;
            }
        } else {
            const code = response.status;
            switch (Number(code)) {
                case 200:
                    return response.data; // Case download excel, not using response entity ApiResponse
                case 400: {
                    this.handleError(response.statusText);
                    break;
                }
                case 401: {
                    this.handleError(response.statusText);
                    break;
                }
                case 404: {
                    this.handleError(response.statusText);
                    break;
                }
                case 500: {
                    this.handleError(response.statusText);
                    break;
                }
                case 502: {
                    this.handleError(response.statusText);
                    break;
                }
                case 504: {
                    this.handleError(response.statusText);
                    break;
                }
                default:
                    return;
            }
        }
    }
}

export default new Utils();
