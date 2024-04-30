import React, { useState } from 'react'
import {Job} from '../../Types/Job'
import { FaMapMarked, FaMarker } from 'react-icons/fa'
import { JobItemProps } from '../../Types/Props/JobItemProps';



const JobItem: React.FC<JobItemProps> = ({ job }) => {

  const [showDescription, setShowDescription] = useState(true);
    
  let description : string = job.description;

  if (!showDescription){
     description = description.substring(0, 90) + '  ';
  }

  return (
    <div id={`job-${job.id}`} className="bg-white rounded-xl shadow-md relative">
    <div className="p-4">
      <div className="mb-6">
        <div className="text-gray-600 my-2">{job.type}</div>
         <h3 className="text-xl font-bold">{job.title}</h3>
      </div>
      <div className="mb-5">
        {description}
      </div>
        <button className="text-indigo-400 mb-5 hover:text-indigo-800" 
          onClick={() => setShowDescription((prevState) => !prevState )}>
          {showDescription ? '  less' : 'read more...' }
        </button>

      <h3 className="text-indigo-500 mb-2">
        {job.salary}
      </h3>

      <div className="border border-gray-100 mb-5"></div>
      <div className="flex flex-col lg:flex-row justify-between mb-4">
        <div className="text-orange-800 mb-3">
          <FaMapMarked className='inline text-lg mb-1 mr-2' />
            {job.location}
        </div>
        <a
          href={`/job/${job.id}`}
          className="h-[36px] bg-indigo-500 hover:bg-indigo-600 text-white px-4 py-2 rounded-lg text-center text-sm">
          Read More
        </a>
      </div>
    </div>
  </div>
  );
};

export default JobItem