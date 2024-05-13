import axios from 'axios';
import { Job } from '../Types/Job';

class JobService {
    private baseUrl: string = 'http://localhost:8000/jobs';

    public async getJobs(num : number) : Promise<Job[]> {
        try {
            const response = await axios.get<Job[]>(this.baseUrl + `?_limit=${num}`);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching jobs');
        }
    };

    public async getJob(num : number) : Promise<Job>{
        try {
            console.log(num);
            const response = await axios.get<Job>(this.baseUrl + `/${num}`);
            return response.data;
        }
        catch (error) {
            throw new Error('Error fetching job');
        }
    };

    public addJob = async (newJob : Job ) => {
        try {
            const request = await axios.post<Job>(this.baseUrl, newJob, {
                headers: {
                    'Content-Type': 'application/json',
                }
            });
            return request.data;
        }
        catch(error) {
            throw new Error('Error adding job');
        }
      };

    public updateJob = async (updateJob : Job) => {
        try {
            const request = await axios.put<Job>(this.baseUrl + `/${updateJob.id}`, updateJob, {
                headers: {
                    'Content-Type': 'application/json',
                }
                });
                return request.data;
        }
        catch(error) {
            throw new Error('Error edit job');
        }
    };
      
    
      public deleteJob = async (jobId : number) => {
        try{
            await axios.delete(this.baseUrl + `/${jobId}`);
        }
        catch {
            throw new Error('Error deleteing job');
        }
      };
}

export const jobService = new JobService();
