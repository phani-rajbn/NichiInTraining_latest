var calc = function () {
			this.addFunc = function(v1, v2){
				return v1 + v2;
			}
			this.subFunc = function(v1, v2){
				return v1 - v2;
			}
			this.mulFunc = function(v1, v2){
				return v1 * v2;
			}
			this.divFunc = function(v1, v2){
				return v1 / v2;
			}
			this.sqrt = function(v1){
				return Math.sqrt(v1);//BuiltIn function of the Math class to return the Square Root of the number...
			}
			this.sqr = function(v1){
				return this.mulFunc(v1, v2);//reusability...
			}
		}