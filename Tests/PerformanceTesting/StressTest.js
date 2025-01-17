import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    // Key configurations for Stress in this section
    stages: [
        { duration: '1m', target: 200 }, // traffic ramp-up from 1 to a higher 200 users over 10 minutes.
        { duration: '2m', target: 200 }, // stay at higher 200 users for 30 minutes
        { duration: '3m', target: 0 }, // ramp-down to 0 users
    ],
};

export default () => {
    const urlRes = http.get('https://ca3devopsmjtw-qa.azurewebsites.net/');
    sleep(1);
    // MORE STEPS
    // Here you can have more steps or complex script
    // Step1
    // Step2
    // etc.
};
