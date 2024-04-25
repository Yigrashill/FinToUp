import React from 'react'
import {Job} from '../../Types/Job'

interface JobItemProps {
  job: Job;
}

const JobItem: React.FC<JobItemProps> = ({ job }) => {
  return (
    <div id={`job-${job.id}`} className="bg-white rounded-xl shadow-md relative">
    <div className="p-4">
      <div className="mb-6">
        <div className="text-gray-600 my-2">{job.type}</div>
         <h3 className="text-xl font-bold">{job.title}</h3>
      </div>
      <div className="mb-5">
        {job.description}
      </div>
      <h3 className="text-indigo-500 mb-2">
        {job.salary}
      </h3>

      <div className="border border-gray-100 mb-5"></div>

      <div className="flex flex-col lg:flex-row justify-between mb-4">
        <div className="text-orange-700 mb-3">
          <i className="fa-solid fa-location-dot text-lg"></i>
            {job.location}
        </div>
        <a
          href="job.html"
          className="h-[36px] bg-indigo-500 hover:bg-indigo-600 text-white px-4 py-2 rounded-lg text-center text-sm">
          Read More
        </a>
      </div>
    </div>
  </div>
  );
};

export default JobItem