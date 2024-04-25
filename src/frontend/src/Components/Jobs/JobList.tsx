import React from 'react'
import JobItem from './JobItem';
import jobs from '../../data/jobs.json'
import {Job} from '../../Types/Job'

const JobList = () => {
  return (
    <section className="bg-blue-50 px-4 py-10">
        <div className="container-xl lg:container m-auto">
            <h2 className="text-3xl font-bold text-indigo-500 mb-6 text-center">
                Browse Jobs
            </h2>
                <div className='grid grid-col-1 mdLgrid-col-5 gap-6'>
                    {
                        jobs.map((job: Job) => (
                            <JobItem key={job.id} job={job} />
                        ))
                    }
                </div>
        </div>
      </section>
  );
};

export default JobList
