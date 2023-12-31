import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 10,
    duration: '5m',
};

export default function () {
    let res = http.get('"https://ca3devopsmjtw-qa.azurewebsites.net/');
    check(res, { 'status was 200': (r) => r.status == 200 });
    sleep(1);
};

