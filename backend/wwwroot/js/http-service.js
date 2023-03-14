class HttpService {
    /**
     * perform GET ajax request with token
     * @param url url to send ajax request
     * @returns {Promise<*>}
     */
    getAsync(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: url,
                beforeSend: function (xhr) {
                    if (localStorage.token) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.token);
                    }
                },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, err) {
                    reject(jqXHR)
                }
            });
        })
    }

    /**
     * perform POST ajax request with token
     * @param url url to send ajax request
     * @param data data to send in body
     * @returns {Promise<*>}
     */
    postAsync(url, data) {
        // if data is not string, serialize it
        if (typeof data != "string") {
            data = JSON.stringify(data);
        }
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: url,
                data: data,
                beforeSend: function (xhr) {
                    if (localStorage.token) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.token);
                    }
                },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, err) {
                    reject(jqXHR)
                }
            });
        })
    }

    /**
     * perform PUT ajax request with token
     * @param url url to send ajax request
     * @param data data to send in body
     * @returns {Promise<*>}
     */
    putAsync(url, data) {
        // if data is not string, serialize it
        if (typeof data != "string") {
            data = JSON.stringify(data);
        }
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'PUT',
                url: url,
                data: data,
                beforeSend: function (xhr) {
                    if (localStorage.token) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.token);
                    }
                },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, err) {
                    reject(jqXHR)
                }
            });
        })
    }

    /**
     * perform DELETE ajax request with token
     * @param url url to send ajax request
     * @returns {Promise<*>}
     */
    deleteAsync(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'DELETE',
                url: url,
                beforeSend: function (xhr) {
                    if (localStorage.token) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.token);
                    }
                },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, err) {
                    reject(jqXHR)
                }
            });
        })
    }
}