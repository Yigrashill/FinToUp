import React, {useState, useEffect} from 'react'
import JobItem from './JobItem';
import jobs from '../../data/jobs.json'
import {Job} from '../../Types/Job'
import { JobListProps } from '../../Types/Props/JobListProps';

const JobList: React.FC<JobListProps> = ({isHome}) => {

   const recentJobs = isHome  ? jobs.slice(0,3) : jobs;
        
   return (
        <>
            <div className="container-xl lg:container m-auto">
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
            </div>
        </>
  );
};

export default JobList
