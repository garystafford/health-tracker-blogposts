“
sC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\Activity.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

class 
Activity 
{ 
public 
int 

ActivityId 
{ 
get  #
;# $
set% (
;( )
}* +
[

 	
Required

	 
]

 
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
] 
[ 	
EnumDataType	 
( 
typeof 
( 
ActivityType )
)) *
)* +
]+ ,
public 
ActivityType 
ActivityTypeId *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage '
=( )
$str 4
)4 5
]5 6
public 
string 
Notes 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
int 
PersonId 
{ 
get !
;! "
set# &
;& '
}( )
public 
virtual 
Person 
Person $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ¼
wC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\ActivityType.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

enum 
ActivityType 
{ 
	Treadmill 
, 
Jogging 
, 
WeightTraining 
, 
Biking 
, 
Aerobics		 
,		 
Other

 
} 
} ÿ
sC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\MealType.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

enum 
MealType 
{ 
	Breakfast 
, 
[		 	
Display			 
(		 
Name		 
=		 
$str		 %
)		% &
]		& '

MidMorning

 
,

 
Lunch 
, 
[ 	
Display	 
( 
Name 
= 
$str '
)' (
]( )
MidAfternoon 
, 
Dinner 
, 
Snack 
, 
Brunch 
, 
Other 
} 
} Ú

|C:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\PersonSummaryView.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

class 
PersonSummaryView "
{ 
[ 	
Required	 
] 
public 
int 
PersonSummaryViewId &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public		 
int		 
PersonId		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
int 
ActivitiesCount "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 

MealsCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
HydrationCount !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} Ó
wC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\HealthTrackerContext.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
{ 
public 

class  
HealthTrackerContext %
:& '
	DbContext( 1
{ 
public  
HealthTrackerContext #
(# $
)$ %
:		 
base		 
(		 
$str		 1
)		1 2
{

 	
} 	
public 
DbSet 
< 
Activity 
> 

Activities )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
DbSet 
< 
	Hydration 
> 

Hydrations  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
DbSet 
< 
Meal 
> 
Meals  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DbSet 
< 
Person 
> 
Persons $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DbSet 
< 
PersonSummaryView &
>& '
PersonSummaryViews( :
{; <
get= @
;@ A
setB E
;E F
}G H
} 
} ã
tC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\Hydration.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

class 
	Hydration 
{ 
public 
int 
HydrationId 
{  
get! $
;$ %
set& )
;) *
}+ ,
[

 	
Required

	 
]

 
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
] 
[ 	
Range	 
( 
$num 
, 
$num 
, 
ErrorMessage "
=# $
$str% O
)O P
]P Q
public 
int 
Count 
{ 
get 
; 
set  #
;# $
}% &
[ 	
Required	 
] 
public 
int 
PersonId 
{ 
get !
;! "
set# &
;& '
}( )
public 
virtual 
Person 
Person $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} 
oC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\Meal.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

class 
Meal 
{ 
public 
int 
MealId 
{ 
get 
;  
set! $
;$ %
}& '
[

 	
Required

	 
]

 
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
] 
[ 	
EnumDataType	 
( 
typeof 
( 
MealType %
)% &
)& '
]' (
public 
MealType 

MealTypeId "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage '
=( )
$str ;
); <
]< =
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
] 
public 
int 
PersonId 
{ 
get !
;! "
set# &
;& '
}( )
public 
virtual 
Person 
Person $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ¿
qC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Classes\Person.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #
Classes# *
{ 
public 

class 
Person 
{ 
public 
int 
PersonId 
{ 
get !
;! "
set# &
;& '
}( )
[

 	
Required

	 
]

 
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage '
=( )
$str* R
)R S
,S T
	MinLength 
( 
$num 
, 
ErrorMessage !
=" #
$str$ J
)J K
]K L
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
virtual 
List 
< 
Meal  
>  !
Meals" '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
virtual 
List 
< 
Activity $
>$ %

Activities& 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
virtual 
List 
< 
	Hydration %
>% &

Hydrations' 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
} 
} ª
{C:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Migrations\Configuration.cs
	namespace 	
HealthTracker
 
. 

DataAccess "
." #

Migrations# -
{ 
internal 
sealed 
class 
Configuration '
:( )%
DbMigrationsConfiguration* C
<C D
HealthTrackerD Q
.Q R

DataAccessR \
.\ ] 
HealthTrackerContext] q
>q r
{		 
public

 
Configuration

 
(

 
)

 
{ 	&
AutomaticMigrationsEnabled &
=' (
true) -
;- .
} 	
	protected 
override 
void 
Seed  $
($ %
HealthTracker% 2
.2 3

DataAccess3 =
.= > 
HealthTrackerContext> R
contextS Z
)Z [
{ 	
} 	
} 
} ¥
zC:\Users\gary.stafford\Source\Repos\health-tracker-blogposts\HealthTracker.DataAccess.CodeFirst\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 3
)3 4
]4 5
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str &
)& '
]' (
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str 5
)5 6
]6 7
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 9
)9 :
]: ;
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *