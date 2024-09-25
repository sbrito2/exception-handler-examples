package com.example.controllers.Base;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import com.example.models.response.ApiReturn;

public class BaseController {
    protected ResponseEntity<ApiReturn> ok(ApiReturn apiReturn) {
        if (apiReturn.isHasNotifications())
            return new ResponseEntity<>(apiReturn, HttpStatus.BAD_REQUEST);

        int statusCode = this.getHttpStatusCode(apiReturn);
        return new ResponseEntity<>(apiReturn, HttpStatus.valueOf(statusCode));
    }

    private  int getHttpStatusCode(ApiReturn apiReturn) {
        if (apiReturn == null) {
            return HttpStatus.UNPROCESSABLE_ENTITY.value();
        }
        if (apiReturn.isErrorOccurred()) {
            return HttpStatus.BAD_REQUEST.value();
        }
        return HttpStatus.OK.value();
    }
}


