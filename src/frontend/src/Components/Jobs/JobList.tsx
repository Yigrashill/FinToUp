import React, {useState, useEffect} from 'react'
import JobItem from './JobItem';
import {Job} from '../../Types/Job'
import {JobListProps} from '../../Types/Props/JobListProps';
import Spinner from '../../Components/Spinner';
import { jobService } from '../../Services/jobService';

const JobList: React.FC<JobListProps> = ({isHome}) => {

    const [jobs, setJobs] = useState<Job[]>([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const fetchJobs = async () => {
            setLoading(true);

            try {
                const data = await jobService.getJobs();
                setJobs(data);  
            }
            catch(error) {
                console.log('Error fetching jobs', error);
            }
            finally {
                setLoading(false);
            }
        }

        fetchJobs();
    }, []);

   const recentJobs = isHome  ? jobs.slice(0, 3) : jobs;
        
   return (
        <>
            <div className="container-xl lg:container m-auto">
            {loading 
                ? 
                ( <>
                     <h2 className="text-3xl font-bold text-yellow mb-6 text-center">
                        loadding..
                    </h2>
                        <Spinner loading = { loading } />
                </>)
                : 
                ( <>
                    <h2 className="text-3xl font-bold text-white mb-6 text-center">
                        Browse Jobs 
                    </h2>
                    <div className='grid grid-col-1 md:grid-cols-3 gap-6'>
                    {
                        recentJobs.map((job: Job) => (
                            <JobItem key={job.id} job={job} />
                        ))
                    } 
                   </div>
                </>)
            }
            </div>
        </>
  );
};

export default JobList
